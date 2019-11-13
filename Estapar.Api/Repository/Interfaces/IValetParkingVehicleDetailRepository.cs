using Estapar.Api.Model;
using Estapar.Api.Repository.Interfaces.Base;
using System.Collections.Generic;

namespace Estapar.Api.Repository.Interfaces
{
    public interface IValetParkingVehicleDetailRepository : IRepository<ValetParkingVehicleDetail>
    {
        IEnumerable<ValetParkingVehicleDetail> GetAllDetails();
        ValetParkingVehicleDetail Get(ValetParkingVehicleDetail model);
        ValetParkingVehicleDetail GetDetail(ValetParkingVehicleDetail model);
    }
}
