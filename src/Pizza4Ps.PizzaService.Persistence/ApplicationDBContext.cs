using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Pizza4Ps.PizzaService.Domain.Abstractions.Entities;
using Pizza4Ps.PizzaService.Domain.Entities;
using Pizza4Ps.PizzaService.Domain.Entities.Identity;
using Pizza4Ps.PizzaService.Persistence.Configurations;
using Pizza4Ps.PizzaService.Persistence.Intercepter;
using Pizza4Ps.PizzaService.Persistence.Repositories;
using System.Linq.Expressions;

namespace Pizza4Ps.PizzaService.Persistence
{
    public sealed class ApplicationDBContext : IdentityDbContext<AppUser, AppRole, Guid>
    {
        private readonly AuditSaveChangesInterceptor _auditInterceptor;

        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options, AuditSaveChangesInterceptor auditInterceptor)
            : base(options)
        {
            _auditInterceptor = auditInterceptor;
        }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            var softDeleteEntities = typeof(ISoftDelete).Assembly.GetTypes()
                .Where(type => typeof(ISoftDelete).IsAssignableFrom(type)
                && type.IsClass
                && !type.IsAbstract);
            foreach (var softDeleteEntity in softDeleteEntities)
            {
                builder.Entity(softDeleteEntity).HasQueryFilter(GenerateQueryFilterLambda(softDeleteEntity));
            }
            builder.ApplyConfigurationsFromAssembly(AssemblyReference.Assembly);
        }

        private LambdaExpression? GenerateQueryFilterLambda(Type type)
        {
            var parameter = Expression.Parameter(type, "w");
            var falseConstantValue = Expression.Constant(false);
            var propertyAccess = Expression.PropertyOrField(parameter, nameof(ISoftDelete.IsDeleted));
            var equalExpression = Expression.Equal(propertyAccess, falseConstantValue);
            var lambda = Expression.Lambda(equalExpression, parameter);
            return lambda;
        }

        #region Configuration DbSet
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<AppRole> AppRoles { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Config> Configs { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Option> Options { get; set; }
        public DbSet<OptionItem> OptionItems { get; set; }
        public DbSet<OptionItemOrderItem> OptionItemOrderItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderVoucher> OrderVouchers { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Staff> Staffs { get; set; }
        public DbSet<StaffSchedule> StaffSchedules { get; set; }
        public DbSet<StaffZone> StaffZones { get; set; }
        public DbSet<StaffZoneSchedule> StaffZoneSchedules { get; set; }
        public DbSet<Table> Tables { get; set; }
        public DbSet<TableBooking> TableBookings { get; set; }
        public DbSet<Voucher> Vouchers { get; set; }
        public DbSet<Zone> Zones { get; set; }
        #endregion
    }
}
