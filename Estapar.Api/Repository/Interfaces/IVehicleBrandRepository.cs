using Estapar.Api.Model;
using Estapar.Api.Repository.Interfaces.Base;

namespace Estapar.Api.Repository.Interfaces
{
    public interface IVehicleBrandRepository : IRepository<VehicleBrand>
    {
        VehicleBrand GetByName(VehicleBrand model);
        bool HasAssociation(VehicleBrand model);
    }
}
