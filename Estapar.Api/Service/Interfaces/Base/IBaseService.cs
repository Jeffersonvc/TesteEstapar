using System.Collections.Generic;

namespace Estapar.Api.Service.Interfaces.Base
{
    public interface IBaseService<TDTO>
    {
        IEnumerable<TDTO> GetAll();
        IEnumerable<TDTO> GetActives();
        TDTO GetById(int id);
        bool Update(TDTO dto);
        bool Delete(TDTO dto);
        bool Insert(TDTO dto);
    }
}
