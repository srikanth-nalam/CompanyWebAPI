using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyOwnerWebAPI.Dtos
{
    public class GetCompanyDto
    {
        public string CompanyName { get; set; }

        public string Country { get; set; }

        public long PhoneNumber { get; set; }       

        public List<GetUserDto> UserDetails { get; set; }
        
    }
}
