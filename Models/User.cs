using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyOwnerWebAPI.Models
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public long SSN { get; set; }        
        public List<CompanyUser> CompanyUsers { get; set; }
    }
}
