using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using YuzTanima.Core.Entities.Abstract;

namespace YuzTanima.Entities.Concrete
{
    public class CalisanYollari : IEntity
    {
        [Key]
        public Guid calisanYollariId { get; set; }
        public Guid calisanId { get; set; }
        public Guid kameraId { get; set; }
        public int siraNo { get; set; }
    }
}
