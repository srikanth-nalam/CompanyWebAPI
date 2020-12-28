using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyOwnerWebAPI.Dtos
{
    public class AddCompanyUserDto
    {
        public int CompanyId { get; set; }
        public int UserId { get; set; }
        public int RoleId { get; set; }
    }
}
