using System.Collections.Generic;
using System.Linq;
using YuzTanima.Core.DataAccess.EntityFramework;
using YuzTanima.DataAccess.Abstract;
using YuzTanima.Entities.Concrete;
using YuzTanima.Entities.Dtos;

namespace YuzTanima.DataAccess.Concrete.EntityFramework
{
    public class EfZiyartcilerDal : EfEntityRepositoryBase<Ziyaretciler, DatabaseContext>, IZiyaretcilerDal
    {
        public List<GetZiyaretcilerDto> ZiyaretcileriGetir()
        {
            using (DatabaseContext db=new DatabaseContext())
            {
                var result = (from ziyaretci in db.Ziyaretciler
                        join calisan in db.Calisanlar
                            on ziyaretci.calisanId equals calisan.calisanId
                        select new GetZiyaretcilerDto
                        {
                            adsoyad = ziyaretci.ad + " " + ziyaretci.soyad,
                            calisanIsmi = calisan.calisanAd + " " + calisan.calisanSoyad,
                            resimUrl = ziyaretci.resimUrl,
                            telefon = ziyaretci.telefon,
                            ziyaretciId = ziyaretci.ziyaretciId
                        }
                    ).ToList();
                return result;
            }
        }
    }
}
