using Estapar.Core.Pagination;
using Estapar.Core.Repository.Database;
using Estapar.Core.Repository.Specific.MSSQL;
using System;
using System.Collections.Generic;

namespace Estapar.Core.Repository.Base
{
    public class BaseRepository<TModel> : IBaseRepository<TModel> where TModel : class
    {
        protected readonly string _connectionString;
        protected IBaseRepository<TModel> _repository;
        protected ScriptGenerator<TModel> _scriptGenerator;

        public BaseRepository(string connectionString, DBInstance dBInstance = DBInstance.SQLServer)
        {
            _connectionString = connectionString;
            _scriptGenerator = new ScriptGenerator<TModel>();
            ConstructInstance(dBInstance);
        }

        private void ConstructInstance(DBInstance dBInstance)
        {
            switch (dBInstance)
            {
                case DBInstance.SQLServer:
                    _repository = new BaseSQLRepository<TModel>(_connectionString);
                    break;
                default:
                    _repository = new BaseSQLRepository<TModel>(_connectionString);
                    break;
            }
        }

        public bool ExecuteCommand(string query, Dictionary<string, object> parameters)
        {
            return _repository.ExecuteCommand(query, parameters);
        }

        public bool ExecuteCommandExists(string query, Dictionary<string, object> parameters)
        {
            return _repository.ExecuteCommandExists(query, parameters);
        }
        public IEnumerable<TModel> ExecuteCommandList(string query, Dictionary<string, object> parameters)
        {
            return _repository.ExecuteCommandList(query, parameters);
        }

        public TModel ExecuteCommandObject(string query, Dictionary<string, object> parameters)
        {
            return _repository.ExecuteCommandObject(query, parameters);
        }

        public Paging<TModel> ExecuteCommandPage(string query, Dictionary<string, object> parameters, int page = 1, int pageSize = 10)
        {
            return _repository.ExecuteCommandPage(query, parameters, page, pageSize);
        }

        public IEnumerable<TModel> GetAll()
        {
            return _repository.GetAll();

        }
        public bool Update(TModel model)
        {
            return _repository.Update(model);
        }
        public bool Delete(TModel model)
        {
            return _repository.Delete(model);
        }
        public TModel GetById(TModel model)
        {
            return _repository.GetById(model);
        }
        public bool Insert(TModel model)
        {
            return _repository.Insert(model);
        }
    }
}
