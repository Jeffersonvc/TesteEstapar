using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Estapar.Api.DTO;
using Estapar.Api.Service;
using Estapar.Api.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Estapar.Api.Controllers
{
    [Route("api/valet-parking")]
    [ApiController]
    public class ValetParkingController : BaseController<ValetParkingService, ValetParkingDTO>
    {
        public ValetParkingController(IValetParkingService service) : base((ValetParkingService)service)
        {

        }
        [Route("get-by-document/{document}")]
        [HttpGet]
        public IActionResult Exists(string document)
        {
            var result = _service.GetByDocument(document);
            return new JsonResult(result != null);
        }

        [Route("has-association")]
        [HttpPost]
        public IActionResult HasAssociation([FromBody]ValetParkingDTO dto)
        {
            var result = _service.HasAssociation(dto);
            return new JsonResult(result);
        }
    }
}