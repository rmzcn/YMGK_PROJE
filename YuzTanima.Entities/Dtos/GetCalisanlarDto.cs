using System;
using System.Collections.Generic;
using System.Text;

namespace YuzTanima.Entities.Dtos
{
    public class GetCalisanlarDto
    {
        public Guid calisanId { get; set; }
        public string ad { get; set; }
        public string soyad { get; set; }
        public string birimAdi { get; set; }
    }
}
