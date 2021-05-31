using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using YuzTanima.Core.Entities.Abstract;

namespace YuzTanima.Entities.Concrete
{
    public class Calisanlar : IEntity
    {
        [Key]
        public Guid calisanId { get; set; }
        public string calisanAd { get; set; }
        public string calisanSoyad { get; set; }
        public Guid birimId { get; set; }
        public string resimUrl { get; set; }
    }
}
