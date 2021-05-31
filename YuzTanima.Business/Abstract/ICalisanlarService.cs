using System;
using System.Collections.Generic;
using System.Text;
using YuzTanima.Core.Utilities.Results;
using YuzTanima.Entities.Concrete;
using YuzTanima.Entities.Dtos;

namespace YuzTanima.Business.Abstract
{
    public interface ICalisanlarService
    {
        IDataResult<List<DropdownDto>> GetEmployeesForDropdown();
        IResult Add(AddCalisanDto model);
        IDataResult<Calisanlar> GetCalisan(Guid calisanId);
        IDataResult<List<GetCalisanlarDto>> GetCalisanlar();
    }
}
