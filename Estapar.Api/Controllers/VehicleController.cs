using Estapar.Api.DTO;
using Estapar.Api.Service;
using Estapar.Api.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Estapar.Api.Controllers
{
    [Route("api/vehicle")]
    [ApiController]
    public class VehicleController : BaseController<VehicleService, VehicleDTO>
    {
        public VehicleController(IVehicleService service) : base((VehicleService)service)
        {

        }

        [Route("get-by-plate/{plate}")]
        [HttpGet]
        public IActionResult GetByPlate(string plate)
        {
            var result = _service.GetByPlate(plate);
            return new JsonResult(result != null);
        }

        [Route("has-association")]
        [HttpPost]
        public IActionResult HasAssociation([FromBody]VehicleDTO dto)
        {
            var result = _service.HasAssociation(dto);
            return new JsonResult(result);
        }
    }
}