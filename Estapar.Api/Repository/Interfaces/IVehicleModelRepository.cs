using Estapar.Api.Model;
using Estapar.Api.Repository.Interfaces.Base;

namespace Estapar.Api.Repository.Interfaces
{
    public interface IVehicleModelRepository : IRepository<VehicleModel>
    {
        VehicleModel GetByName(VehicleModel model);
        bool HasAssociation(VehicleModel model);
    }
}
