using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Estapar.Api.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Estapar.Api.Controllers
{
    [Route("api/valet-parking-vehicle-detail")]
    [ApiController]
    public class ValetParkingVehicleDetailController : Controller
    {
        protected IValetParkingVehicleDetailService _service;

        public ValetParkingVehicleDetailController(IValetParkingVehicleDetailService service)
        {
            _service = service;
        }
        [Route("get")]
        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _service.GetAllDetails();
            return new JsonResult(result);
        }

        [Route("get/{id}")]
        [HttpGet]
        public IActionResult Get(int id)
        {
            var result = _service.Get(id);
            return new JsonResult(result);
        }
    }
}