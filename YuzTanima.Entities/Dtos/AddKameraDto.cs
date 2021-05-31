using System;
using System.Collections.Generic;
using System.Text;
using YuzTanima.Core.Entities.Abstract;

namespace YuzTanima.Entities.Dtos
{
    public class AddKameraDto:IDto
    {
        public string isim { get; set; }
        public string kullaniciadi { get; set; }
        public string sifre { get; set; }
        public string ipadresi { get; set; }
    }
}
