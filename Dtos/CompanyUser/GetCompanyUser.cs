using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyOwnerWebAPI.Dtos.CompanyUser
{
    public class GetCompanyUser
    {
        public int UserId { get; set; }
        public int RoleId { get; set; }
    }
}
