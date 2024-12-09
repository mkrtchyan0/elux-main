using Elux.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Elux.Dal.Data.Configurations
{
    public class ServiceConfiguration : IEntityTypeConfiguration<Service>
    {
        public void Configure(EntityTypeBuilder<Service> builder)
        {
            // Primary Key
            builder.HasKey(x => x.Id);

            //// Relationship Configuration
            //builder.HasOne(service => service.ServiceGroup)
            //    .WithMany(group => group.Services)
            //    .HasForeignKey(service => service.ServiceGroupId)
            //    .IsRequired();

            // Property Configurations
            builder.Property(x => x.Id)
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(x => x.ServiceName)
                .IsRequired()
                .HasMaxLength(256);

            builder.Property(x => x.Price)
                .IsRequired();

            builder.Property(x => x.Duration)
                .IsRequired();
        }
    }
}
