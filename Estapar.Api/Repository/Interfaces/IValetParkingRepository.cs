using Estapar.Api.Model;
using Estapar.Api.Repository.Interfaces.Base;

namespace Estapar.Api.Repository.Interfaces
{
    public interface IValetParkingRepository : IRepository<ValetParking>
    {
        ValetParking GetByDocument(string document);
        bool HasAssociation(ValetParking model);
    }
}
