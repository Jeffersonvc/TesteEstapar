using Estapar.Api.DTO;
using Estapar.Api.Service.Interfaces.Base;

namespace Estapar.Api.Service.Interfaces
{
    public interface IVehicleModelService : IBaseService<VehicleModelDTO>
    {
        VehicleModelDTO GetByName(VehicleModelDTO dto);
        bool HasAssociation(VehicleModelDTO dto);
    }
}
