using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using YuzTanima.Core.Entities.Abstract;

namespace YuzTanima.Entities.Concrete
{
    public class Raporlar : IEntity
    {
        [Key]
        public Guid raporId { get; set; }
        public Guid tipId { get; set; }
        public string mesaj { get; set; }
    }
}
