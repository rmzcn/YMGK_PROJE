using System;
using System.Collections.Generic;
using System.Text;
using YuzTanima.Core.Entities.Abstract;

namespace YuzTanima.Entities.Dtos
{
    public class GetZiyaretcilerDto : IDto
    {
        public Guid ziyaretciId { get; set; }
        public string adsoyad { get; set; }
        public string telefon { get; set; }
        public string calisanIsmi { get; set; }
        public string resimUrl { get; set; }
        
    }
}
