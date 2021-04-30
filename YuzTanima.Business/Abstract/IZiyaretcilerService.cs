using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using YuzTanima.Core.Utilities.Results;
using YuzTanima.Entities.Dtos;

namespace YuzTanima.Business.Abstract
{
    public interface IZiyaretcilerService
    {
        IResult AddVisitor(AddVisitorDto model);

        IResult AddPhoto(IFormFile file);
    }
}
