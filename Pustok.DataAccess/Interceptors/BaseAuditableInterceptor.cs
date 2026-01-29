using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Pustok.Core.Entites.Common;
using Pustok.DataAccess.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pustok.DataAccess.Interceptors
{
    internal class BaseAuditableInterceptor:SaveChangesInterceptor
    {
        public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
        {
            UpdateAuditColumns(eventData);
            return base.SavingChangesAsync(eventData, result, cancellationToken);
        }

        private static void UpdateAuditColumns(DbContextEventData eventData)
        {
            if (eventData.Context is AppDbContext appDbContext)
            {
                var entries = appDbContext.ChangeTracker.Entries<BaseAuditableEntity>().ToList();
                foreach (var entry in entries)
                {
                    switch (entry.State)
                    {
                        case EntityState.Added:
                            entry.Entity.CreatedDate = DateTime.Now;
                            entry.Entity.CreatedBy = "Elcin";
                            break;
                        case EntityState.Modified:
                            entry.Entity.UpdatedDate = DateTime.Now;
                            entry.Entity.UpdatedBy = "Elcin";
                            break;
                        case EntityState.Deleted:
                            entry.Entity.DeletedDate = DateTime.Now;
                            entry.Entity.DeletedBy = "Elcin";
                            entry.Entity.IsDeleted = true;
                            entry.State = EntityState.Modified;
                            break;
                    }
                }
            }
        }

        public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
        {
            UpdateAuditColumns(eventData);
            return base.SavingChanges(eventData, result);
        }
    }
}
