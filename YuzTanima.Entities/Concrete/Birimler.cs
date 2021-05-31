using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using YuzTanima.Core.Entities.Abstract;

namespace YuzTanima.Entities.Concrete
{
    public class Birimler : IEntity
    {
        [Key]
        public Guid birimId { get; set; }
        public string birimAdi { get; set; }
    }
}
