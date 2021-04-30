using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YuzTanima.Business.Abstract;
using YuzTanima.Business.Constants;
using YuzTanima.Core.Utilities.Results;
using YuzTanima.DataAccess.Abstract;
using YuzTanima.Entities.Concrete;
using YuzTanima.Entities.Dtos;

namespace YuzTanima.Business.Concrete
{
    public class CalisanYollariManager : ICalisanYollariService
    {
        private ICalisanYollariDal _calisanYollariDal;

        public CalisanYollariManager(ICalisanYollariDal calisanYollariDal)
        {
            _calisanYollariDal = calisanYollariDal;
        }

        public IDataResult<List<GetCalisanYollariPathsDto>> GetCalisanYollariPaths(Guid calisanId)
        {
            var result = _calisanYollariDal.GetAll(x => x.calisanId == calisanId).Select(x => new GetCalisanYollariPathsDto
            {
                kameraId = x.kameraId
            }).ToList();

            return new SuccessDataResult<List<GetCalisanYollariPathsDto>>(result);
        }
        public IResult AddCalisanYollari(List<Guid> cameraIds, Guid calisanId)
        {
            if (cameraIds != null && cameraIds.Count > 0)
            {
                int siraCounter = 1;
                for (int i = 0; i < cameraIds.Count; i++)
                {
                    _calisanYollariDal.Add(new CalisanYollari()
                    {
                        kameraId = cameraIds[i],
                        calisanId = calisanId,
                        calisanYollariId = Guid.NewGuid(),
                        siraNo = siraCounter
                    });
                    siraCounter++;
                }

                return new SuccessResult();
            }

            return new ErrorResult(Messages.CalisanYollariAddedError);
        }
    }
}
