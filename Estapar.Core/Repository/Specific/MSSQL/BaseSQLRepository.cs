using Estapar.Core.Pagination;
using Estapar.Core.Repository.Base;
using Estapar.Core.Repository.Database;
using Estapar.Core.Repository.Helper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace Estapar.Core.Repository.Specific.MSSQL
{
    public class BaseSQLRepository<TModel> : IBaseRepository<TModel> where TModel : class
    {
        protected readonly string _connectionString;
        private ConnectionHelper _connectionMannager;
        private RepositoryHelper<TModel> _repositoryHelper;
        protected ScriptGenerator<TModel> _scriptGenerator;
        private const int defaultPage = 1;
        private const int defaultPageSize = 10;
        public const string queryPage = @" OFFSET (@page - 1) * @pageSize ROWS
							FETCH NEXT @pageSize ROWS ONLY";
        public BaseSQLRepository(string connectionString)
        {
            _connectionString = connectionString;
            _connectionMannager = new ConnectionHelper(DBInstance.SQLServer, _connectionString);
            _repositoryHelper = new RepositoryHelper<TModel>();
            _scriptGenerator = new ScriptGenerator<TModel>();
        }

        private SqlConnection Connection
        {
            get
            {
                return (SqlConnection)_connectionMannager.GetConnection();
            }
        }

        public bool ExecuteCommand(string query, Dictionary<string, object> parameters)
        {
            bool returnValue = true;

            using (SqlCommand cmd = new SqlCommand(query, this.Connection))
            {
                if (parameters != null && parameters.Count > 0)
                    cmd.Parameters.AddRange(parameters.Select(x => new SqlParameter(x.Key, x.Value)).ToArray());
                returnValue = cmd.ExecuteNonQuery() > 0;
            }
            return returnValue;
        }
        public bool ExecuteCommandExists(string query, Dictionary<string, object> parameters)
        {
            bool returnValue = true;

            using (SqlCommand cmd = new SqlCommand(query, this.Connection))
            {
                if (parameters != null && parameters.Count > 0)
                    cmd.Parameters.AddRange(parameters.Select(x => new SqlParameter(x.Key, x.Value)).ToArray());
                var reader = cmd.ExecuteReader();
                returnValue = reader.HasRows;
            }
            return returnValue;
        }
        public TModel ExecuteCommandObject(string query, Dictionary<string, object> parameters)
        {
            using (SqlCommand cmd = new SqlCommand(query, this.Connection))
            {
                if (parameters != null && parameters.Count > 0)
                    cmd.Parameters.AddRange(parameters.Select(x => new SqlParameter(x.Key, x.Value)).ToArray());
                var reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    return _repositoryHelper.DataReaderMapToObject(reader);
                }
            }

            return null;
        }
        public Paging<TModel> ExecuteCommandPage(string query, Dictionary<string, object> parameters, int page = defaultPage, int pageSize = defaultPageSize)
        {
            query = string.Concat(query, queryPage);

            if (!parameters.ContainsKey("@page"))
                parameters.Add("@page", page);
            if (!parameters.ContainsKey("@pageSize"))
                parameters.Add("@pageSize", pageSize);

            using (SqlCommand cmd = new SqlCommand(query, this.Connection))
            {
                if (parameters != null && parameters.Count > 0)
                    cmd.Parameters.AddRange(parameters.Select(x => new SqlParameter(x.Key, x.Value)).ToArray());
                var reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    Paging<TModel> PagingDTO = new Paging<TModel>(_repositoryHelper.DataReaderMapToList(reader), page, pageSize, 0);
                    return PagingDTO;
                }
            }

            return null;
        }
        public IEnumerable<TModel> ExecuteCommandList(string query, Dictionary<string, object> parameters)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query.ToString(), conn))
                {
                    if (parameters != null && parameters.Count > 0)
                        cmd.Parameters.AddRange(parameters.Select(x => new SqlParameter(x.Key, x.Value)).ToArray());
                    var reader = cmd.ExecuteReader();

                    if (reader.HasRows)
                    {
                        return _repositoryHelper.DataReaderMapToList(reader);
                    }
                }

                return null;
            }
        }


        public IEnumerable<TModel> GetAll()
        {
            TModel model = Activator.CreateInstance<TModel>();
            string query = _scriptGenerator.SelectAll(model);
            return ExecuteCommandList(query, null);

        }
        public bool Update(TModel model)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            string query = _scriptGenerator.Update(model, ref parameters);
            return ExecuteCommand(query, parameters);
        }
        public bool Delete(TModel model)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            string query = _scriptGenerator.Delete(model, ref parameters);
            return ExecuteCommand(query, parameters);
        }
        public TModel GetById(TModel model)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            string query = _scriptGenerator.Select(model, ref parameters);
            return ExecuteCommandObject(query, parameters);
        }

        public bool Insert(TModel model)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            string query = _scriptGenerator.Insert(model, ref parameters);
            return ExecuteCommand(query, parameters);
        }
    }
}
