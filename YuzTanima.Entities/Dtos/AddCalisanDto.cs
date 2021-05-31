using System;
using System.Collections.Generic;
using System.Text;
using YuzTanima.Core.Entities.Abstract;

namespace YuzTanima.Entities.Dtos
{
    public class AddCalisanDto :IDto
    {
        public string ad { get; set; }
        public string soyad { get; set; }
        public Guid birimId  { get; set; }
        public List<Guid> cameraPaths { get; set; }
    }
}
