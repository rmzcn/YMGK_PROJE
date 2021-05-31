using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YuzTanima.Business.Abstract;
using YuzTanima.Entities.Dtos;

namespace YuzTanima.WebService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private IZiyaretcilerService _ziyaretcilerService;

        public ReportController(IZiyaretcilerService ziyaretcilerService)
        {
            _ziyaretcilerService = ziyaretcilerService;
        }

        [HttpPost("izinsorgula")]
        public IActionResult IzinSorgula(ZiyaretciRaporlaDto model)
        {
            var result = _ziyaretcilerService.ZiyaretciYetkiSorgula(model);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }
    }
}
