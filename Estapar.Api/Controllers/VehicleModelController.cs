using Estapar.Api.DTO;
using Estapar.Api.Service;
using Estapar.Api.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Estapar.Api.Controllers
{
    [Route("api/vehicle-model")]
    [ApiController]
    public class VehicleModelController : BaseController<VehicleModelService, VehicleModelDTO>
    {
        public VehicleModelController(IVehicleModelService service) : base((VehicleModelService)service)
        {

        }

        [Route("get-by-name")]
        [HttpPost]
        public IActionResult Exists([FromBody]VehicleModelDTO dto)
        {
            var result = _service.GetByName(dto);
            return new JsonResult(result != null);
        }

        [Route("has-association")]
        [HttpPost]
        public IActionResult HasAssociation([FromBody]VehicleModelDTO dto)
        {
            var result = _service.HasAssociation(dto);
            return new JsonResult(result);
        }
    }
}