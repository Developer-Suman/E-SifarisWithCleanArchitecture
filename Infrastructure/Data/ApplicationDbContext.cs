using Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
     public sealed class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        public DbSet<Branch> Branches { get; set; }
        public DbSet<BranchType> BranchTypes { get; set; }
        public DbSet<Proviance> Proviances { get; set; }
        public DbSet<District> Districts { get; set; }
        public DbSet<Municipality> municipalities { get; set; }
        public DbSet<Vdc> Vdcs { get; set; }
        public DbSet<Department> Departments { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
