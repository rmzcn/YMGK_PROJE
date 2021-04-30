using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using YuzTanima.Business.Abstract;
using YuzTanima.Business.Constants;
using YuzTanima.Core.Utilities.FileHelper;
using YuzTanima.Core.Utilities.Results;
using YuzTanima.DataAccess.Abstract;
using YuzTanima.Entities.Dtos;

namespace YuzTanima.Business.Concrete
{
    public class ZiyaretcilerManager : IZiyaretcilerService
    {
        private IZiyaretcilerDal _ziyaretcilerDal;

        public ZiyaretcilerManager(IZiyaretcilerDal ziyaretcilerDal)
        {
            _ziyaretcilerDal = ziyaretcilerDal;
        }

        public IResult AddPhoto(IFormFile file)
        {
            throw new NotImplementedException();
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
