using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YuzTanima.Business.Abstract;
using YuzTanima.Core.Utilities.FileHelper;
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
        private IRaporlarService _raporlarService;

        public YonetimController(ICalisanlarService calisanlarService, IZiyaretcilerService ziyaretcilerService, IKameralarService kameralarService, IBirimlerService birimlerService, IRaporlarService raporlarService)
        {
            _ziyaretcilerService = ziyaretcilerService;
            _kameralarService = kameralarService;
            _birimlerService = birimlerService;
            _raporlarService = raporlarService;
            _calisanlarService = calisanlarService;
        }

        [HttpGet("getallemployeeoptions")]
        public IActionResult GetAllEmployeeOptions()
        {
            return Ok(_calisanlarService.GetEmployeesForDropdown());
        }


        [HttpPost("ziyaretciekle")]
        public IActionResult ZiyaretciEkle([FromForm] AddVisitorDto model)
        {
            return Ok(_ziyaretcilerService.AddVisitor(model));
        }

        [HttpGet("ziyaretcileri-getir")]
        public IActionResult ZiyaretcileriGetir()
        {
            return Ok(_ziyaretcilerService.GetVisitors());
        }

        [HttpGet("kameralar")]
        public IActionResult Kameralar()
        {
            return Ok(_kameralarService.GetAllForDropdown());
        }

        [HttpGet("kameralari-getir")]
        public IActionResult KameralariGetir()
        {
            return Ok(_kameralarService.GetAll());
        }

        [HttpPost("kamera-ekle")]
        public IActionResult Kameralar(AddKameraDto model)
        {
            return Ok(_kameralarService.AddCamera(model));
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

        [HttpGet("calisanlar")]
        public IActionResult Calisanlar()
        {
            return Ok(_calisanlarService.GetCalisanlar());
        }

        [HttpGet("raporlar")]
        public IActionResult Raporlar()
        {
            return Ok(_raporlarService.RaporlariGetir());
        }

        [HttpPost("kameraguncelle")]
        public IActionResult KameraGuncelle(KameraDto model)
        {
            ChangeName.Change(model.kameraId);
            return Ok();
        }

        [HttpGet("kamerabilgileri")]
        public IActionResult KameraBilgileri(Guid kameraId)
        {
            var model = new KameraDto()
            {
                kameraId = kameraId
            };
            var result = _kameralarService.KameraBilgileriniGetir(model);
            return Ok(result);
        }

    }
}
