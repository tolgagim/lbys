using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Server.Application.Common.Events;
using Server.Application.Common.Interfaces;
using Server.Domain.Catalog;
using Server.Infrastructure.Identity;
using Server.Infrastructure.Persistence.Configuration;

namespace Server.Infrastructure.Persistence.Context;
public class ApplicationDbContext : BaseDbContext
{
    public ApplicationDbContext(DbContextOptions options, ICurrentUser currentUser, ISerializerService serializer, IOptions<DatabaseSettings> dbSettings, IEventPublisher events)
        : base(options, currentUser, serializer, dbSettings, events)
    {
    }

    public DbSet<Product> Products => Set<Product>();
    public DbSet<Brand> Brands => Set<Brand>();
    public DbSet<Customer> Customers => Set<Customer>();
    public DbSet<SmsSend> SmsSends => Set<SmsSend>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.HasDefaultSchema(SchemaNames.Catalog);

        // ApplicationUser ile Customer arasindaki iliskiyi yapilandir
        modelBuilder.Entity<ApplicationUser>()
            .HasOne(a => a.Customer)
            .WithMany()// Eger bir Customer birden fazla ApplicationUser ile iliskili olabilirse
            .HasForeignKey(a => a.CustomerId)
            .IsRequired(false);  // CustomerId nullable oldugundan
    }
}
