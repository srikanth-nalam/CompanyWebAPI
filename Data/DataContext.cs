using CompanyOwnerWebAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyOwnerWebAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options): base(options) { }        

        public DbSet<Company> Companies { get; set; }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<CompanyUser> CompanyUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Company>()
                        .HasKey(c => c.Id);

            modelBuilder.Entity<User>()
                        .HasKey(u => u.Id);

            modelBuilder.Entity<CompanyUser>()
                        .HasKey(cu => new { cu.CompanyId, cu.UserId, cu.RoleId });

            modelBuilder.Entity<Role>().HasData(
                new Role { 
                 RoleId = 1,
                 RoleName = "Employee"
                },
                 new Role
                 {
                     RoleId = 2,
                     RoleName = "Owner"
                 },
                  new Role
                  {
                      RoleId = 3,
                      RoleName = "Manager"
                  }
                );

            modelBuilder.Entity<User>().HasData(
                new User {
                   Id = 1,
                   UserName = "TestUser1",
                   SSN = 1001
                },
                new User
                {
                    Id = 2,
                    UserName = "TestUser2",
                    SSN = 1002
                },
                new User
                {
                    Id = 3,
                    UserName = "TestUser3",
                    SSN = 1003
                });

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DataContext).Assembly);
        }
    }

    
}
