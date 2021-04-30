using System;
using System.Collections.Generic;
using System.Text;
using YuzTanima.Core.DataAccess.EntityFramework;
using YuzTanima.DataAccess.Abstract;
using YuzTanima.Entities.Concrete;

namespace YuzTanima.DataAccess.Concrete.EntityFramework
{
    public class EfBirimlerDal : EfEntityRepositoryBase<Birimler,DatabaseContext> , IBirimlerDal
    {
    }
}
