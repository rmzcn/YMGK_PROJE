using YuzTanima.Core.DataAccess.EntityFramework;
using YuzTanima.DataAccess.Abstract;
using YuzTanima.Entities.Concrete;

namespace YuzTanima.DataAccess.Concrete.EntityFramework
{
    public class EfKayitliZiyaretcilerDal : EfEntityRepositoryBase<KayitliZiyaretciler, DatabaseContext>, IKayitliZiyaretcilerDal
    {
    }
}
