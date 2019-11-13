using Estapar.Api.DTO;
using System.Collections.Generic;

namespace Estapar.Api.Service.Interfaces
{
    public interface IValetParkingVehicleDetailService
    {
        IEnumerable<ValetParkingVehicleDetailDTO> GetAllDetails();
        ValetParkingVehicleDetailDTO Get(int id);
    }
}
