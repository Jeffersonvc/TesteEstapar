using Estapar.Api.DTO;
using Estapar.Api.Service.Interfaces.Base;

namespace Estapar.Api.Service.Interfaces
{
    public interface IVehicleService : IBaseService<VehicleDTO>
    {
        VehicleDTO GetByPlate(string plate);
        bool HasAssociation(VehicleDTO dto);
    }
}
