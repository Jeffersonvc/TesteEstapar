using AutoMapper;
using Estapar.Api.DTO;
using Estapar.Api.Model;
using Estapar.Api.Repository.Interfaces;
using Estapar.Api.Service.Base;
using Estapar.Api.Service.Interfaces;

namespace Estapar.Api.Service
{
    public class ValetParkingVehicleService : BaseService<ValetParkingVehicle, ValetParkingVehicleDTO, IValetParkingVehicleRepository>, IValetParkingVehicleService
    {
        public ValetParkingVehicleService(IMapper mapper, IValetParkingVehicleRepository repository) : base(mapper, repository)
        {
        }
    }
}
