using Dapper;
using CarteiraApi.Interfaces.Repositories;
using CarteiraApi.Models.Entities;
using CarteiraApi.Models.Requests.Operation ;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;

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
                            ID,
                            OPERACAO,
                            PRECO,
                            QUANTIDADE,
                            DATA,
                            VALOR_TOTAL,
                            COD_ACAO
                        ) 
                        VALUES
                        (
                            @Id,
                            @Operation,
                            @Price,
                            @Quantity,
                            @Date,
                            @TotalAmount,
                            @StockId
                        ); SELECT LAST_INSERT_ID();";

            await using var conn = new MySqlConnection(_connectionString);
            if (conn.State == ConnectionState.Closed)
                await conn.OpenAsync();

            return await conn.ExecuteScalarAsync<int>(query, request);
        }

        public async Task<IEnumerable<Operation>> Get(OperationGetRequest request)
        {
            var query = @"SELECT 
                            ID Id,
                            ACAO_ID StockId,
                            OPERACAO Order,
                            PRECO Preco,
                            QUANTIDADE Quantidade,
                            DATA Data,
                            VALOR_TOTAL valor_total
                          FROM OPERACOES
                          /**where**/";

            var builder = new SqlBuilder();

            if (!string.IsNullOrEmpty(request.StockCode))
                builder.Where("CODIGO = @StockCode", new { StockCode = request.StockCode });

            var selector = builder.AddTemplate(query);

            await using var conn = new MySqlConnection(_connectionString);
            if (conn.State == ConnectionState.Closed)
                await conn.OpenAsync();

            return await conn.QueryAsync<Operation>(selector.RawSql, selector.Parameters);
        }
    }
}
