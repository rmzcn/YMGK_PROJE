using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using YuzTanima.Core.Utilities.Results;
using YuzTanima.Entities.Concrete;
using YuzTanima.Entities.Dtos;

namespace YuzTanima.Business.Abstract
{
    public interface IZiyaretcilerService
    {
        IResult AddVisitor(AddVisitorDto model);
        IDataResult<List<GetZiyaretcilerDto>> GetVisitors();
        IResult AddPhoto(IFormFile file);

        IResult ZiyaretciYetkiSorgula(ZiyaretciRaporlaDto model);
    }
}
