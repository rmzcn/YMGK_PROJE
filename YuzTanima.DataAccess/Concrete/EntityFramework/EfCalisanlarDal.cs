using YuzTanima.Core.DataAccess.EntityFramework;
using YuzTanima.DataAccess.Abstract;
using YuzTanima.Entities.Concrete;

namespace YuzTanima.DataAccess.Concrete.EntityFramework
{
    public class EfCalisanlarDal : EfEntityRepositoryBase<Calisanlar, DatabaseContext>, ICalisanlarDal
    {
    }
}
