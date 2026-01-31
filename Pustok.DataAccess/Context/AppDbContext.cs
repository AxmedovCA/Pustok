using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Pustok.Core.Entites;
using Pustok.Core.Entites.Common;
using Pustok.DataAccess.Helpers;
using Pustok.DataAccess.Interceptors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Pustok.DataAccess.Context
{
    internal class AppDbContext(BaseAuditableInterceptor interceptor,DbContextOptions options) : IdentityDbContext<AppUser,AppRole,string>(options)
    {
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            modelBuilder.Entity<Employee>().HasQueryFilter(p => !p.IsDeleted);

            var position = new Position()
            {
                Id = Guid.Parse("4e2043c7-ea73-4d39-a5a8-3d14afaeb24d"),
                Name = "Default Position"

            };

            modelBuilder.Entity<Position>().HasData(position); 
            modelBuilder.Entity<Gender>().HasData(StaticData.MaleGender,StaticData.FemaleGender);
            base.OnModelCreating(modelBuilder);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.AddInterceptors(interceptor);
            base.OnConfiguring(optionsBuilder);
        }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Position> Positions { get; set; }
    }
}
