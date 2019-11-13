using Estapar.Api.Service.Interfaces.Base;
using Microsoft.AspNetCore.Mvc;

namespace Estapar.Api.Controllers
{
    public class BaseController<TService, TDTO> : ControllerBase where TService : IBaseService<TDTO>
    {
        protected TService _service;
        public BaseController(TService service)
        {
            _service = service;
        }

        [Route("get")]
        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _service.GetAll();
            return new JsonResult(result);
        }

        [Route("get-active")]
        [HttpGet]
        public IActionResult GetActives()
        {
            var result = _service.GetActives();
            return new JsonResult(result);
        }

        [Route("get/{id}")]
        [HttpGet]
        public IActionResult Get(int id)
        {
            var result = _service.GetById(id);
            return new JsonResult(result);
        }

        [Route("update")]
        [HttpPost]
        public IActionResult Update([FromBody]TDTO dto)
        {
            var result = _service.Update(dto);
            return new JsonResult(result);
        }

        [Route("delete")]
        [HttpPost]
        public IActionResult Delete([FromBody]TDTO dto)
        {
            var result = _service.Delete(dto);
            return new JsonResult(result);
        }

        [Route("insert")]
        [HttpPost]
        public IActionResult Insert([FromBody]TDTO dto)
        {
            var result = _service.Insert(dto);
            return new JsonResult(result);
        }

    }
}