using Cadier.Model.ModelsConfigs;
using Microsoft.AspNetCore.Http;
using System.Data;
using Microsoft.Data.SqlClient;
using static Dapper.SqlMapper;
using Dapper;
using Cadier.Utilitaries.Extensoes;

namespace Cadier.DB.Sessions
{
    public class DbSession : IDisposable
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IDbConnection _connection;
        private IDbTransaction? DbTransaction;
        private readonly BancoConfig _bancoConfig;

        public DbSession(IHttpContextAccessor httpContextAccessor, BancoConfig bancoConfig)
        {
            _httpContextAccessor = httpContextAccessor;
            _bancoConfig = bancoConfig;
            _connection = new SqlConnection(_bancoConfig.ConnectionString);
        }

        public void Dispose() 
        {
            DbTransaction?.Dispose();
            _connection?.Dispose();
        }

        private void BeginTransaction()
        {
            if (DbTransaction == null)
            {
                _connection.Open();
                DbTransaction = _connection.BeginTransaction();
            }
        }

        private void Commit()
        {
            DbTransaction?.Commit();
            DbTransaction?.Dispose();
            DbTransaction = null;
            _connection.Close();
        }

        private void Rollback()
        {
            DbTransaction?.Rollback();
            DbTransaction?.Dispose();
            DbTransaction = null;
            _connection.Close();
        }

        public async Task<string> PegarQueryArquivo(string caminhoScripts) =>
            await GetType().PegarConteudoAsync(caminhoScripts);

        public async Task<T> ExecuteScalarAsync<T>(string query, DynamicParameters? parameters = null)
        {
            query = await PegarQueryArquivo(query);
            parameters ??= new DynamicParameters();
            parameters.Add("SiglaIdioma", GetCurrentCulture() ?? "pt-BR");
            return await _connection.ExecuteScalarAsync<T>(query, parameters, commandTimeout: _bancoConfig.TimeOut);
        }

        public async Task<IEnumerable<T>> QueryAsync<T>(string query, DynamicParameters? parameters = null)
        {
            query = await PegarQueryArquivo(query);
            parameters ??= new DynamicParameters();
            parameters.Add("SiglaIdioma", GetCurrentCulture() ?? "pt-BR");
            return await _connection.QueryAsync<T>(query, parameters, commandTimeout: _bancoConfig.TimeOut);
        }

        public async Task<T> QueryFirstOrDefaultAsync<T>(string query, DynamicParameters? parameters = null)
        {
            query = await PegarQueryArquivo(query);
            parameters ??= new DynamicParameters();
            parameters.Add("SiglaIdioma", GetCurrentCulture() ?? "pt-BR");
            return await _connection.QueryFirstOrDefaultAsync<T>(query, parameters, commandTimeout: _bancoConfig.TimeOut);
        }

        public async Task<GridReader> QueryMultipleAsync(
            string query,
            DynamicParameters? param = null,
            IDbTransaction? transaction = null,
            int? commandTimeout = null,
            CommandType? commandType = null)
        {
            query = await PegarQueryArquivo(query);
            param ??= new DynamicParameters();
            param.Add("SiglaIdioma", GetCurrentCulture() ?? "pt-BR");



            return await _connection.QueryMultipleAsync(query, param, transaction, commandTimeout, commandType);
        }

        public async Task<int?> ExecuteTransactionAsync(string query, DynamicParameters? parameters = null)
        {
            int? id = null;
            BeginTransaction();

            try
            {
                query = await PegarQueryArquivo(query);
                parameters ??= new DynamicParameters();
                parameters.Add("SiglaIdioma", GetCurrentCulture() ?? "pt-BR");
                id = await _connection.QueryFirstOrDefaultAsync<int>(query, parameters, DbTransaction, commandTimeout: _bancoConfig.TimeOut);

                Commit();
                return id;
            }
            catch(Exception ex)
            {
                Rollback();
                return id;
            }
        }

        private string? GetCurrentCulture()
            => _httpContextAccessor.HttpContext?.Request?.Cookies[".AspNetCore.Culture"]?.Split('=').LastOrDefault();

        public async Task<IEnumerable<T1>> QueryAsync<T1, T2, T3, T4, T5>(string query, Func<T1, T2, T3, T4, T5, T1> map, string[] splitOn, DynamicParameters? parameters = null)
        {
            query = await PegarQueryArquivo(query);
            parameters ??= new DynamicParameters();
            parameters.Add("SiglaIdioma", GetCurrentCulture() ?? "pt-BR");

            var results = await _connection.QueryAsync<T1, T2, T3, T4, T5, T1>(
                    query,
                    (objA, objB, objC, objD, objE) =>
                    {                        
                        return map(objA, objB, objC, objD, objE);
                    },
                    parameters,
                    splitOn: string.Join(",", splitOn),
                    commandTimeout: _bancoConfig.TimeOut
                );

            return results;
        }
    }
}