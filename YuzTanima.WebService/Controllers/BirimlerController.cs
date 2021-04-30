using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YuzTanima.Business.Abstract;

namespace YuzTanima.WebService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BirimlerController : ControllerBase
    {
        private IBirimlerService _birimlerService;

        public BirimlerController(IBirimlerService birimlerService)
        {
            _birimlerService = birimlerService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result=_birimlerService.GetAll();
            if (result.Success)
                return Ok(result);
            return BadRequest();
        }
    }
}
