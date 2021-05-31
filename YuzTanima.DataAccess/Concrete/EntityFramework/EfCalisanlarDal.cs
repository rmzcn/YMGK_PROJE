using System.Collections.Generic;
using System.Linq;
using YuzTanima.Core.DataAccess.EntityFramework;
using YuzTanima.DataAccess.Abstract;
using YuzTanima.Entities.Concrete;
using YuzTanima.Entities.Dtos;

namespace YuzTanima.DataAccess.Concrete.EntityFramework
{
    public class EfCalisanlarDal : EfEntityRepositoryBase<Calisanlar, DatabaseContext>, ICalisanlarDal
    {
        public List<GetCalisanlarDto> CalisanlariGetir()
        {
            using (DatabaseContext db = new DatabaseContext())
            {
                var result = (from calisan in db.Calisanlar
                        join birim in db.Birimler
                            on calisan.birimId equals birim.birimId
                        select new GetCalisanlarDto()
                        {
                            ad = calisan.calisanAd,
                            birimAdi = birim.birimAdi,
                            calisanId = calisan.calisanId,
                            soyad = calisan.calisanSoyad
                        }
                    ).ToList();
                return result;
            }
        }
    }
}
