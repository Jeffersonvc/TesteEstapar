using Estapar.Api.DTO;
using Estapar.Api.Service.Interfaces.Base;

namespace Estapar.Api.Service.Interfaces
{
    public interface IValetParkingService : IBaseService<ValetParkingDTO>
    {
        ValetParkingDTO GetByDocument(string document);
        bool HasAssociation(ValetParkingDTO model);
    }
}
