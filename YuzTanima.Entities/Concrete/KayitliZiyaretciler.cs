using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using YuzTanima.Core.Entities.Abstract;

namespace YuzTanima.Entities.Concrete
{
    public class KayitliZiyaretciler : IEntity
    {
        [Key]
        public Guid kayitliZiyaretciId { get; set; }
        public Guid ziyaretciId { get; set; }
        public Guid kameraId { get; set; }
        public DateTime zaman { get; set; }
    }
}
