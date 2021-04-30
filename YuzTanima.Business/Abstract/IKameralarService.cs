using System;
using System.Collections.Generic;
using System.Text;
using YuzTanima.Core.Utilities.Results;
using YuzTanima.Entities.Dtos;

namespace YuzTanima.Business.Abstract
{
    public interface IKameralarService
    {
        DataResult<List<DropdownDto>> GetAllForDropdown();
    }
}
