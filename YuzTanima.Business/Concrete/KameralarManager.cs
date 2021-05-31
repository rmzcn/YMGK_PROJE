using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YuzTanima.Business.Abstract;
using YuzTanima.Business.Constants;
using YuzTanima.Core.Utilities.Results;
using YuzTanima.DataAccess.Abstract;
using YuzTanima.Entities.Concrete;
using YuzTanima.Entities.Dtos;

namespace YuzTanima.Business.Concrete
{
    public class KameralarManager :IKameralarService
    {
        private IKameralarDal _kameralarDal;

        public KameralarManager(IKameralarDal kameralarDal)
        {
            _kameralarDal = kameralarDal;
        }

        public IDataResult<List<DropdownDto>> GetAllForDropdown()
        {
            return new SuccessDataResult<List<DropdownDto>>( _kameralarDal.GetAll().Select(x=> new DropdownDto
            {
                key=x.kameraId,
                value=x.isim
            }).ToList());
        }

        public IDataResult<List<Kameralar>> GetAll()
        {
            return new SuccessDataResult<List<Kameralar>>(_kameralarDal.GetAll());
        }

        public IResult AddCamera(AddKameraDto model)
        {
            string[] protokoller = new[] {"TCP", "UDP"};
            Random rnd = new Random();
            _kameralarDal.Add(new Kameralar()
            {
                isim = model.isim,
                ip = model.ipadresi,
                kameraId = Guid.NewGuid(),
                kullaniciAdi = model.kullaniciadi,
                protokol = rnd.Next(0,protokoller.Length) == 0 ? protokoller[0] : protokoller[1],
                sifre = model.sifre,
            });
            return new SuccessResult(Messages.KameraAdded);
        }

        public IDataResult<Kameralar> KameraBilgileriniGetir(KameraDto model)
        {
            return new SuccessDataResult<Kameralar>(_kameralarDal.Get(x => x.kameraId == model.kameraId));
        }
    }
}
