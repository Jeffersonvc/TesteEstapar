using Estapar.Api.DTO;
using Estapar.Api.Service.Interfaces.Base;

namespace Estapar.Api.Service.Interfaces
{
    public interface IVehicleBrandService : IBaseService<VehicleBrandDTO>
    {
        VehicleBrandDTO GetByName(VehicleBrandDTO dto);
        bool HasAssociation(VehicleBrandDTO model);
    }
}
