using Dapper;
using CarteiraApi.Interfaces.Repositories;
using CarteiraApi.Models.Entities;
using CarteiraApi.Models.Requests.Operation ;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace CarteiraApi.Repositories
{
    [ExcludeFromCodeCoverage]
    public class OperationRepository : IOperationRepository
    {
        private string _connectionString { get; set; }
        public OperationRepository(string conn)
        {
            _connectionString = conn;
        }

        public async Task<int> Add(OperationAddRequest request)
        {
            var query = @"INSERT INTO OPERACOES
                        (
                            OPERACAO,
                            PRECO,
                            QUANTIDADE,
                            DATA,
                            VALOR_TOTAL,
                            ACAO_ID
                        ) 
                        VALUES
                        (
                            @Operation,
                            @Price,
                            @Quantity,
                            @Date,
                            @TotalAmount,
                            @StockId
                        );";

            await using var conn = new SqlConnection(_connectionString);
            if (conn.State == ConnectionState.Closed)
                await conn.OpenAsync();

            return await conn.ExecuteScalarAsync<int>(query, request);
        }

        public async Task<IEnumerable<Operation>> Get(OperationGetRequest request)
        {
            var query = @"SELECT 
                            O.ID Id,
                            O.ACAO_ID StockId,
                            O.OPERACAO Operation,
                            O.PRECO Price,
                            O.QUANTIDADE Quantity,
                            O.DATA Date,
                            O.VALOR_TOTAL TotalAmount
                            
                          FROM OPERACOES AS O
                            INNER JOIN
                            ACOES AS A
                            ON O.ACAO_ID = A.ID

                          /**where**/";

            var builder = new SqlBuilder();

            if (!string.IsNullOrEmpty(request.StockCode))
                builder.Where("A.CODIGO = @StockCode", new { StockCode = request.StockCode });

            var selector = builder.AddTemplate(query);

            await using var conn = new SqlConnection(_connectionString);
            if (conn.State == ConnectionState.Closed)
                await conn.OpenAsync();

            return await conn.QueryAsync<Operation>(selector.RawSql, selector.Parameters);
        }
    }
}
