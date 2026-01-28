using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pustok.Core.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pustok.DataAccess.Context.Configurations
{
    internal class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.Property(x => x.Name).IsRequired().HasMaxLength(256);
            builder.Property(x=>x.ImagePath).IsRequired().HasMaxLength(1024);
            builder.Property(x=>x.Salary).IsRequired().HasPrecision(10,2);

            builder.HasOne(x => x.Position).WithMany(x => x.Employees).
                HasForeignKey(x => x.PositionId).
                HasPrincipalKey(x => x.Id).
                OnDelete(DeleteBehavior.Restrict);
        }
    }
}
