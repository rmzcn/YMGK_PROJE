using System;
using System.Collections.Generic;
using System.Text;
using YuzTanima.Core.Utilities.Results;
using YuzTanima.Entities.Concrete;
using YuzTanima.Entities.Dtos;

namespace YuzTanima.Business.Abstract
{
    public interface IKameralarService
    {
        IDataResult<List<DropdownDto>> GetAllForDropdown();
        IDataResult<List<Kameralar>> GetAll();
        IResult AddCamera(AddKameraDto model);
        IDataResult<Kameralar> KameraBilgileriniGetir(KameraDto model);
    }
}
