using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using YuzTanima.Core.Entities.Abstract;

namespace YuzTanima.Entities.Concrete
{
    public class CalisanKameralari : IEntity
    {
        [Key]
        public Guid calisanKameralariId { get; set; }
        public Guid calisanId { get; set; }
        public Guid kameraId { get; set; }
    }
}
