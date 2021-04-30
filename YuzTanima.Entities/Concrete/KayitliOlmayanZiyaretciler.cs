using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using YuzTanima.Core.Entities.Abstract;

namespace YuzTanima.Entities.Concrete
{
    public class KayitliOlmayanZiyaretciler : IEntity
    {
        [Key]
        public Guid kayitliOlmayanZiyaretciId { get; set; }
        public string ziyaretci { get; set; }
        public Guid kameraId { get; set; }
        public DateTime zaman { get; set; }
    }
}
