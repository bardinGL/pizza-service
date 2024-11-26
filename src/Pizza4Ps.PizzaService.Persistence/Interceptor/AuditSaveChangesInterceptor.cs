using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Pizza4Ps.PizzaService.Persistence.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizza4Ps.PizzaService.Persistence.Intercepter
{
    public class AuditSaveChangesInterceptor : SaveChangesInterceptor
    {
        private readonly IHttpContextAccessor _httpContextAcessor;

        public AuditSaveChangesInterceptor(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAcessor = httpContextAccessor;
        }

        public override async ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
        {
            var context = eventData.Context;
            if (context == null) return await base.SavingChangesAsync(eventData, result, cancellationToken);

            // Lấy thông tin người dùng hiện tại
            var userId = _httpContextAcessor?.HttpContext?.GetCurrentUserId();

            // Duyệt qua các thay đổi trong ChangeTracker
            foreach (var entry in context.ChangeTracker.Entries())
            {
                if (entry.State == EntityState.Added)
                {
                    if (entry.Property("CreatedDate") != null)
                        entry.Property("CreatedDate").CurrentValue = DateTimeOffset.UtcNow;

                    if (entry.Property("CreatedBy") != null)
                        entry.Property("CreatedBy").CurrentValue = userId != null ? userId : null;
                }
                else if (entry.State == EntityState.Modified && entry.Property("IsDeleted").IsModified == false)
                {
                    if (entry.Property("ModifiedDate") != null)
                        entry.Property("ModifiedDate").CurrentValue = DateTimeOffset.UtcNow;

                    if (entry.Property("ModifiedBy") != null)
                        entry.Property("ModifiedBy").CurrentValue = userId != null ? userId : null;
                }
                else if (entry.State == EntityState.Modified && entry.Property("IsDeleted").IsModified == true && (bool) entry.Property("IsDeleted").CurrentValue == true)
                {
                    if (entry.Property("DeletedBy") != null)
                        entry.Property("DeletedBy").CurrentValue = userId != null ? userId : null;
                    if (entry.Property("DeletedAt") != null)
                        entry.Property("DeletedAt").CurrentValue = DateTimeOffset.UtcNow;
                }
                else if (entry.State == EntityState.Modified && entry.Property("IsDeleted").IsModified == true && (bool) entry.Property("IsDeleted").CurrentValue == false)
                {
                    if (entry.Property("DeletedBy") != null)
                        entry.Property("DeletedBy").CurrentValue = null;
                    if (entry.Property("DeletedAt") != null)
                        entry.Property("DeletedAt").CurrentValue = null;
                }
            }

            // Gọi base logic
            return await base.SavingChangesAsync(eventData, result, cancellationToken);
        }
    }
}
