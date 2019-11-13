using Estapar.Api.DTO;
using Estapar.Api.Service;
using Estapar.Api.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Estapar.Api.Controllers
{
    [Route("api/vehicle-brand")]
    [ApiController]
    public class VehicleBrandController : BaseController<VehicleBrandService, VehicleBrandDTO>
    {
        public VehicleBrandController(IVehicleBrandService service) : base((VehicleBrandService)service)
        {

        }

        [Route("get-by-name")]
        [HttpPost]
        public IActionResult Exists([FromBody]VehicleBrandDTO dto)
        {
            var result = _service.GetByName(dto);
            return new JsonResult(result != null);
        }

        [Route("has-association")]
        [HttpPost]
        public IActionResult HasAssociation([FromBody]VehicleBrandDTO dto)
        {
            var result = _service.HasAssociation(dto);
            return new JsonResult(result);
        }
    }
}