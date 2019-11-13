using Estapar.Api.DTO;
using Estapar.Api.Service;
using Estapar.Api.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Estapar.Api.Controllers
{
    [Route("api/valet-parking-vehicle")]
    [ApiController]
    public class ValetParkingVehicleController : BaseController<ValetParkingVehicleService, ValetParkingVehicleDTO>
    {
        public ValetParkingVehicleController(IValetParkingVehicleService service) : base((ValetParkingVehicleService)service)
        {

        }
    }
}