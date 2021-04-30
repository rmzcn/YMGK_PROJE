using System;
using System.Collections.Generic;
using System.Text;
using YuzTanima.Core.Utilities.Results;
using YuzTanima.Entities.Dtos;

namespace YuzTanima.Business.Abstract
{
    public interface ICalisanYollariService
    {
        IDataResult<List<GetCalisanYollariPathsDto>> GetCalisanYollariPaths(Guid calisanId);

        IResult AddCalisanYollari(List<Guid> cameraIds, Guid calisanId);
    }
}
