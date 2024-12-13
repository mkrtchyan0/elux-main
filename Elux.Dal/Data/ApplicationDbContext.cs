using Elux.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Elux.Dal.Data
{
    // ApplicationDbContext extends IdentityDbContext to integrate ASP.NET Core Identity
    // with custom ApplicationUser class and other entities.
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
    {
        private IConfiguration _configuration;

        // Constructor that takes configuration and DbContextOptions as parameters
        public ApplicationDbContext(IConfiguration configuration, DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            _configuration = configuration;
        }

        // DbSet properties represent tables in the database
        public DbSet<ApplicationExpert> Experts { get; set; }
        // DbSet for ServiceGroup and Service tables
        public DbSet<ServiceGroup> ServiceGroups { get; set; }
        public DbSet<Service> Services { get; set; }
        // DbSet for ContactRequest and Cart-related entities 
        public DbSet<ContactRequest> ContactRequests { get; set; }
        public DbSet<AboutUs> About { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        //public DbSet<Post>
        public DbSet<CartDraftItem> CartDrafts { get; set; }
        public DbSet<CartItem> Carts { get; set; }
        //public DbSet<BookServiceItem> BookServiceItems { get; set; }

        // Configures the context to use Npgsql (PostgreSQL) as the database provider
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            // Uses the connection string defined in appsettings.json (or another configuration source)
            optionsBuilder.UseNpgsql(_configuration.GetConnectionString("Postgres"));
        }

        // Configures the model using Fluent API
        protected override void OnModelCreating(ModelBuilder builder)
        {
            // Calls the base class method to apply default identity configurations
            base.OnModelCreating(builder);

            // Applies custom configurations from the same assembly as ApplicationDbContext
            builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

            // Configures the UserView entity to map to a database view
            builder
                .Entity<UserView>()
                .ToView("usersview") // Maps to the usersview database view
                .HasKey(t => t.Id);  // Sets the primary key for UserView entity
        }
    }
}
