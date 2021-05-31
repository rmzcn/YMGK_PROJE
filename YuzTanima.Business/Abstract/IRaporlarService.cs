using System;
using System.Collections.Generic;
using System.Text;
using YuzTanima.Core.Utilities.Results;
using YuzTanima.Entities.Concrete;

namespace YuzTanima.Business.Abstract
{
    public interface IRaporlarService
    {
        IResult RaporEkle(bool isAuthorized, string message);
        IDataResult<List<Raporlar>> RaporlariGetir();
    }
}
