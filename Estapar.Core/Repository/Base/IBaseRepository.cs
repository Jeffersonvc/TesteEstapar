using Estapar.Core.Pagination;
using System.Collections.Generic;

namespace Estapar.Core.Repository.Base
{
    public interface IBaseRepository<TModel>
    {
        bool ExecuteCommand(string query, Dictionary<string, object> parameters);
        bool ExecuteCommandExists(string query, Dictionary<string, object> parameters);
        TModel ExecuteCommandObject(string query, Dictionary<string, object> parameters);
        IEnumerable<TModel> ExecuteCommandList(string query, Dictionary<string, object> parameters);
        Paging<TModel> ExecuteCommandPage(string query, Dictionary<string, object> parameters, int page = 1, int pageSize = 10);
        IEnumerable<TModel> GetAll();
        bool Update(TModel model);
        bool Delete(TModel model);
        TModel GetById(TModel model);
        bool Insert(TModel model);
    }
}
