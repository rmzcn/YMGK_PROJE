using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace YuzTanima.Entities.Dtos
{
    public class AddVisitorDto
    {
        public string name { get; set; }
        public string surname { get; set; }
        public string phoneNumber { get; set; }
        public Guid employeeId { get; set; }
        public string address { get; set; }
        public string photoPath { get; set; }
        public string fileName { get; set; }
        public IFormFile file { get; set; }
    }
}
