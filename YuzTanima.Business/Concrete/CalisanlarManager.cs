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
    public class CalisanlarManager : ICalisanlarService
    {
        private ICalisanlarDal _calisanlarDal;
        private ICalisanYollariService _calisanYollariService;

        public CalisanlarManager(ICalisanlarDal calisanlarDal, ICalisanYollariService calisanYollariService)
        {
            _calisanlarDal = calisanlarDal;
            _calisanYollariService = calisanYollariService;
        }

        public IDataResult<List<DropdownDto>> GetEmployeesForDropdown()
        {
            var result = _calisanlarDal.GetAll().Select(x => new DropdownDto
            {
                key = x.calisanId,
                value = x.calisanAd + " " + x.calisanSoyad
            }).ToList();
            return new SuccessDataResult<List<DropdownDto>>(result);
        }

        public IResult Add(AddCalisanDto model)
        {
            Guid calisanId=Guid.NewGuid();
            _calisanlarDal.Add(new Calisanlar()
            {
                birimId = model.birimId,
                calisanAd = model.ad,
                calisanSoyad = model.soyad,
                calisanId = calisanId,
                resimUrl = null
            });

            _calisanYollariService.AddCalisanYollari(model.cameraPaths, calisanId);

            return new SuccessResult(Messages.CalisanAdded);
        }
    }
}
