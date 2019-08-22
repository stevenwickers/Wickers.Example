﻿using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Wickers.DOTNET.Example.Data.Dapper.Exceptions;
using Wickers.DOTNET.Example.Data.Dapper.Interfaces;

namespace Wickers.DOTNET.Example.Data.Dapper
{
    /// <summary>
    /// SQL Dapper Repository Layer
    /// </summary>
    public class DapperRepository : IDapperRepository
    {
        private readonly string _connectionString;
        private readonly int _commandTimeout;

        /// <summary>
        /// SMTP Model is nullable for tesing purposes
        /// </summary>
        /// <param name="ConnectionString">Valid SQL Conneciton String</param>
        /// <param name="SmtpModel">Represents the SMTP Settings</param>
        public DapperRepository(string ConnectionString, int CommandTimeout)
        {
            _connectionString = ConnectionString;
            _commandTimeout = CommandTimeout;
        }

        /// <summary>
        /// Selects a single row from database given a condition
        /// </summary>
        /// <typeparam name="T">Model type to returned</typeparam>
        /// <param name="ProcedureName">SQL Procedure Name</param>
        /// <param name="Parameters">DyanmicParameters</param>
        /// <returns>Returns one record of type T</returns>
        public async Task<T> QuerySingle<T>(string ProcedureName, DynamicParameters Parameters = null)
        {
            using (IDbConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    var result = await connection.QueryAsync<T>(ProcedureName, Parameters, commandType: CommandType.StoredProcedure);

                    return result.FirstOrDefault();
                }
                catch (System.Exception e)
                {
                    //Throw Exception
                    throw new DapperExceptions(e.Message, e.InnerException);
                }
            }

        }

        /// <summary>
        /// Returns multiple row from database given a condition
        /// </summary>
        /// <typeparam name="T">Model type to returned</typeparam>
        /// <param name="ProcedureName">SQL Procedure Name</param>
        /// <param name="Parameters">DyanmicParameters</param>
        /// <returns>Returns a list of type T</returns>
        public async Task<IEnumerable<T>> QueryData<T>(string ProcedureName, DynamicParameters Parameters = null)
        {
            
            using (IDbConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    return await connection.QueryAsync<T>(ProcedureName,
                        Parameters,
                        commandTimeout: _commandTimeout,
                        commandType: CommandType.StoredProcedure);
                }
                catch (System.Exception e)
                {
                    //Throw Exception
                    throw new DapperExceptions(e.Message, e.InnerException);
                }
            }
        }
        
        /// <summary>
        /// Common Execute Proc with results
        /// </summary>
        /// <param name="ProcedureName">SQL Procedure Name</param>
        /// <param name="Parameters">DyanmicParameters</param>
        /// <returns>Returns results from proc as int</returns>
        public async Task<int> ExecuteProc(string ProcedureName, DynamicParameters Parameters)
        {
            using (IDbConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    return await connection.ExecuteAsync(ProcedureName,
                        Parameters,
                        commandTimeout: _commandTimeout,
                        commandType: CommandType.StoredProcedure);
                }
                catch (System.Exception e)
                {

                    //Throw Exception
                    throw new DapperExceptions(e.Message, e.InnerException);
                }

            }

        }

        /// <summary>
        /// Call this to use OUTPUT parameter
        /// </summary>
        /// <typeparam name="T">Model type to returned</typeparam>
        /// <param name="ProcedureName">SQL Procedure Name</param>
        /// <param name="Parameters">DyanmicParameters</param>
        /// <returns>Returns type of T</returns>
        public async Task<T> ExecuteScalarProc<T>(string ProcedureName, DynamicParameters Parameters)
        {
            using (IDbConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    return await connection.ExecuteScalarAsync<T>(ProcedureName,
                        Parameters,
                        commandTimeout: _commandTimeout,
                        commandType: CommandType.StoredProcedure);
                }
                catch (System.Exception e)
                {
                    //Throw Exception
                    throw new DapperExceptions(e.Message, e.InnerException);
                }

            }

        }

    }
}
