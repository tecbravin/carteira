using Dapper;
using CarteiraApi.Interfaces.Repositories;
using CarteiraApi.Models.Entities;
using CarteiraApi.Models.Requests.Stock;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace CarteiraApi.Repositories
{
    [ExcludeFromCodeCoverage]
    public class StockRepository : IStockRepository
    {
        private string _connectionString { get; set; }
        public StockRepository(string conn)
        {
            _connectionString = conn;
        }

        public async Task<int> Add(StockAddRequest request)
        {
            var query = @"INSERT INTO ACOES
                        (
                            CODIGO,
                            RAZAO_SOCIAL
                        ) 
                        VALUES
                        (
                            @StockCode,
                            @CompanyName
                        ); SELECT LAST_INSERT_ID();";

            await using var conn = new SqlConnection(_connectionString);
            if (conn.State == ConnectionState.Closed)
                await conn.OpenAsync();

            return await conn.ExecuteScalarAsync<int>(query, request);
        }

        public async Task Update(StockUpdateRequest request)
        {
            var query = @"UPDATE ACOES SET
                          CODIGO = @StockCode,
                          RAZAO_SOCIAL = @CompanyName
                          WHERE ID = @Id";

            await using var conn = new SqlConnection(_connectionString);
            if (conn.State == ConnectionState.Closed)
                await conn.OpenAsync();

            await conn.ExecuteScalarAsync(query, request);
        }

        public async Task<IEnumerable<Stock>> Search(StockGetRequest request = null)
        {
            var query = @"SELECT 
                            ID Id, 
                            CODIGO StockCode,
                            RAZAO_SOCIAL CompanyName
                          FROM ACOES
                          /**where**/";

            var builder = new SqlBuilder();

            if (request != null)
            {
                if (request.Id.HasValue)
                    builder.Where("ID = @Id", new { Id = request.Id });

                if (!string.IsNullOrEmpty(request.StockCode))
                    builder.Where("CODIGO = @StockCode", new { StockCode = request.StockCode });
            }

            var selector = builder.AddTemplate(query);
            await using var conn = new SqlConnection(_connectionString);
            if (conn.State == ConnectionState.Closed)
                await conn.OpenAsync();

            return await conn.QueryAsync<Stock>(selector.RawSql, selector.Parameters);
        }

        public async Task<bool> Exists(StockGetRequest request)
        {
            var query = @"SELECT 
                            1
                          FROM ACOES
                          WHERE CODIGO = @StockCode
                          LIMIT 1";

            await using var conn = new SqlConnection(_connectionString);
            if (conn.State == ConnectionState.Closed)
                await conn.OpenAsync();

            return await conn.QueryFirstOrDefaultAsync<bool>(query, request);
        }
    }
}
