using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using YuzTanima.Core.Entities.Abstract;

namespace YuzTanima.Entities.Concrete
{
    public class RaporTipleri : IEntity
    {
        [Key]
        public Guid tipId { get; set; }
        public string tipAdi { get; set; }
    }
}
