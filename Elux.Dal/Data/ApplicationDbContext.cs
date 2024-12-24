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

        public DbSet<ApplicationExpert> Experts { get; set; }
        public DbSet<ServiceGroup> ServiceGroups { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<ContactRequest> ContactRequests { get; set; }
        public DbSet<AboutUs> About { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        //public DbSet<Post> 
        public DbSet<CartDraftItem> CartDrafts { get; set; }
        public DbSet<CartItem> Carts { get; set; }
        public DbSet<BookServiceItem> BookServiceItems { get; set; }
        public DbSet<BookServiceItemDraft> BookServiceItemsDraft { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(_configuration.GetConnectionString("Postgres"));
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

            builder
                .Entity<UserView>()
                .ToView("usersview")
                .HasKey(t => t.Id); 
        }
    }
}
