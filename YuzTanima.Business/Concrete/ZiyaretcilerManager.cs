using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YuzTanima.Business.Abstract;
using YuzTanima.Business.Constants;
using YuzTanima.Core.Utilities.FileHelper;
using YuzTanima.Core.Utilities.Results;
using YuzTanima.DataAccess.Abstract;
using YuzTanima.Entities.Concrete;
using YuzTanima.Entities.Dtos;

namespace YuzTanima.Business.Concrete
{
    public class ZiyaretcilerManager : IZiyaretcilerService
    {
        private IZiyaretcilerDal _ziyaretcilerDal;
        private ICalisanlarService _calisanlarService;
        private ICalisanYollariService _calisanYollariService;
        private IRaporlarService _raporlarService;

        public ZiyaretcilerManager(IZiyaretcilerDal ziyaretcilerDal, ICalisanlarService calisanlarService, ICalisanYollariService calisanYollariService, IRaporlarService raporlarService)
        {
            _ziyaretcilerDal = ziyaretcilerDal;
            _calisanlarService = calisanlarService;
            _calisanYollariService = calisanYollariService;
            _raporlarService = raporlarService;
        }

        public IDataResult<List<GetZiyaretcilerDto>> GetVisitors()
        {
            return new SuccessDataResult<List<GetZiyaretcilerDto>>(_ziyaretcilerDal.ZiyaretcileriGetir());
        }

        public IResult AddPhoto(IFormFile file)
        {
            throw new NotImplementedException();
        }

        public IResult ZiyaretciYetkiSorgula(ZiyaretciRaporlaDto model)
        {
            bool Kontrol = true;
            var ziyaretci = _ziyaretcilerDal.Get(x => x.ziyaretciId == model.ziyaretciId);
            var calisan = _calisanlarService.GetCalisan(ziyaretci.calisanId);
            var calisanYollari = _calisanYollariService.GetCalisanYollariPaths(calisan.Data.calisanId);
            foreach (var calisanYolu in calisanYollari.Data)
            {
                if (calisanYolu.kameraId == model.kameraId)
                {
                    Kontrol = false;
                    break;
                }
            }

            if (Kontrol)
            {
                _raporlarService.RaporEkle(false, Messages.NotAuthorized);
                return new ErrorResult(Messages.NotAuthorized);
            }

            _raporlarService.RaporEkle(true, Messages.Authorized);
            return new SuccessResult(Messages.Authorized);
        }

        public IResult AddVisitor(AddVisitorDto model)
        {
            Guid ziyaretciId = Guid.NewGuid();
            var path = FileHelper.AddAsync(model.file, ziyaretciId);
            _ziyaretcilerDal.Add(new Entities.Concrete.Ziyaretciler
            {
                ad = model.name,
                adres = model.address,
                calisanId = model.employeeId,
                soyad = model.surname,
                telefon = model.phoneNumber,
                resimUrl = path,
                ziyaretciId = ziyaretciId,
            });


            

            return new SuccessResult(Messages.ZiyaretcilerAdded);
        }
    }
}
