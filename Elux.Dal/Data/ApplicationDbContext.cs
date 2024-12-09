using Elux.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Elux.Dal.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
    {
        private IConfiguration _configuration;
        public ApplicationDbContext(IConfiguration configuration, DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            _configuration = configuration;
        }
        public DbSet<ApplicationExpert> Experts { get; set; }
        //public DbSet<Skill> Skills { get; set; }
        public DbSet<ServiceGroup> ServiceGroups { get; set; }
        public DbSet<Service> Services { get; set; }
        //public DbSet<UserView> UsersView { get; set; }
        public DbSet<ContactRequest> ContactRequests { get; set; }
        public DbSet<CartDraftItem> CartDrafts { get; set; }
        public DbSet<CartItem> Carts { get; set; }
        public DbSet<BookServiceItem> BookServiceItems { get; set; }
       
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
