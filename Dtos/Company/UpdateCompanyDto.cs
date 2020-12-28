using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyOwnerWebAPI.Dtos
{
    public class UpdateCompanyDto
    {
        public int Id { get; set; }
        public string CompanyName { get; set; } = "Frodo";
        public string Country { get; set; } = "INDIA";
        public long PhoneNumber { get; set; } = 10000000;
        
    }
}
