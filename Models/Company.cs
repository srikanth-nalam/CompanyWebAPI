using System.Collections.Generic;


namespace CompanyOwnerWebAPI.Models
{
    public class Company
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }

        public string Country { get; set; }

        public long PhoneNumber { get; set; }

        public List<CompanyUser> CompanyUsers { get; set; }
    }
}
