using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YuzTanima.Business.Abstract;
using YuzTanima.Core.Utilities.Results;
using YuzTanima.DataAccess.Abstract;
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

        public DataResult<List<DropdownDto>> GetAllForDropdown()
        {
            return new SuccessDataResult<List<DropdownDto>>( _kameralarDal.GetAll().Select(x=> new DropdownDto
            {
                key=x.kameraId,
                value=x.isim
            }).ToList());
        }
    }
}
