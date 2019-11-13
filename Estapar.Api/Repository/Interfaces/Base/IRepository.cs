using Estapar.Core.Repository.Base;
using System.Collections.Generic;

namespace Estapar.Api.Repository.Interfaces.Base
{
    public interface IRepository<TModel> : IBaseRepository<TModel>
    {
        IEnumerable<TModel> GetActives();
    }
}
