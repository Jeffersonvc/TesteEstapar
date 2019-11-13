using Estapar.Api.Model;
using Estapar.Api.Repository.Interfaces.Base;

namespace Estapar.Api.Repository.Interfaces
{
    public interface IVehicleRepository : IRepository<Vehicle>
    {
        Vehicle GetByPlate(string plate);
        bool HasAssociation(Vehicle model);
    }
}
