﻿using Dapper;
using CarteiraApi.Interfaces.Repositories;
using CarteiraApi.Models.Entities;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace CarteiraApi.Repositories
{
    [ExcludeFromCodeCoverage]
    public class StockParameterRepository : IStockParameterRepository
    {
        private string _connectionString { get; set; }
        public StockParameterRepository(string conn)
        {
            _connectionString = conn;
        }

        public async Task<StockParameter> Get(int id)
        {
            var query = @"SELECT 
                            ID Id,
                            VALUE Value
                          FROM ACOES_PARAMETER
                          WHERE ID = @Id";

            await using var conn = new SqlConnection(_connectionString);
            if (conn.State == ConnectionState.Closed)
                await conn.OpenAsync();

            return await conn.QueryFirstOrDefaultAsync<StockParameter>(query, new { Id = id });
        }
    }
}
