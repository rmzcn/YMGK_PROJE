using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using YuzTanima.Core.Entities.Abstract;

namespace YuzTanima.Entities.Concrete
{
    public class Kameralar : IEntity
    {
        [Key]
        public Guid kameraId { get; set; }
        public string kullaniciAdi { get; set; }
        public string sifre { get; set; }
        public string ip { get; set; }
        public string isim { get; set; }
        public string uzanti { get; set; }
        public string protokol { get; set; }
    }
}
