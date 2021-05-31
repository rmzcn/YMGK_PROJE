using System;
using System.Collections.Generic;
using System.Text;
using YuzTanima.Core.DataAccess;
using YuzTanima.Entities.Concrete;
using YuzTanima.Entities.Dtos;

namespace YuzTanima.DataAccess.Abstract
{
    public interface ICalisanlarDal : IEntityRepository<Calisanlar>
    {
        List<GetCalisanlarDto> CalisanlariGetir();
    }
}
