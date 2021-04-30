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
    public class YonetimController : ControllerBase
    {
        private ICalisanlarService _calisanlarService;
        private IZiyaretcilerService _ziyaretcilerService;
        private IKameralarService _kameralarService;
        private IBirimlerService _birimlerService;

        public YonetimController(ICalisanlarService calisanlarService, IZiyaretcilerService ziyaretcilerService, IKameralarService kameralarService, IBirimlerService birimlerService)
        {
            _ziyaretcilerService = ziyaretcilerService;
            _kameralarService = kameralarService;
            _birimlerService = birimlerService;
            _calisanlarService = calisanlarService;
        }

        [HttpGet("getallemployeeoptions")]
        public IActionResult GetAllEmployeeOptions()
        {
            return Ok(_calisanlarService.GetEmployeesForDropdown());
        }


        [HttpPost("ziyaretciekle")]
        public IActionResult ZiyaretciEkle([FromForm]AddVisitorDto model)
        {
            return Ok(_ziyaretcilerService.AddVisitor(model));
        }

        [HttpGet("kameralar")]
        public IActionResult Kameralar()
        {
            return Ok(_kameralarService.GetAllForDropdown());
        }

        [HttpGet("birimler")]
        public IActionResult Birimler()
        {
            return Ok(_birimlerService.GetBirimlerForDropdown());
        }

        [HttpPost("calisanekle")]
        public IActionResult CalisanEkle(AddCalisanDto model)
        {
            return Ok(_calisanlarService.Add(model));
        }

    }
}
