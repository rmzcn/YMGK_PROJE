using System;
using System.Collections.Generic;
using System.Text;
using YuzTanima.Business.Abstract;
using YuzTanima.Core.Utilities.Results;
using YuzTanima.DataAccess.Abstract;
using YuzTanima.Entities.Concrete;

namespace YuzTanima.Business.Concrete
{
    public class RaporlarManager : IRaporlarService
    {
        private IRaporlarDal _raporlarDal;

        public RaporlarManager(IRaporlarDal raporlarDal)
        {
            _raporlarDal = raporlarDal;
        }

        public IResult RaporEkle(bool isAuthorized, string message)
        {
            _raporlarDal.Add(new Raporlar()
            {
                mesaj = message,
                raporId = Guid.NewGuid(),
                tipId = (isAuthorized == true
                    ? Guid.Parse("5247324D-127E-426C-B716-EE1F52B91BD4")
                    : Guid.Parse("1ECF7F54-17EC-492D-850B-3391A99514CD"))
            });
            return new SuccessResult();
        }

        public IDataResult<List<Raporlar>> RaporlariGetir()
        {
            return new SuccessDataResult<List<Raporlar>>(_raporlarDal.GetAll());
        }
    }
}
