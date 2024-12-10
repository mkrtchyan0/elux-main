using Elux.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Elux.Dal.Data.Configurations
{
    // Configuration for the ServiceGroup entity
    public class ServiceGroupConfiguration : IEntityTypeConfiguration<ServiceGroup>
    {
        public void Configure(EntityTypeBuilder<ServiceGroup> builder)
        {
            // Set the primary key for the ServiceGroup entity
            builder.HasKey(x => x.Id);

            // Configure the Id property to be required and auto-generated
            builder.Property(x => x.Id)
                .IsRequired() // Ensures the field is not nullable
                .ValueGeneratedOnAdd(); // Auto-generates the value when a new record is created

            // Configure the ServiceGroupName property to be required
            builder.Property(x => x.ServiceGroupName)
                .IsRequired(); // Ensures the field is not nullable

            // Configure the ServiceDescription property to be required
            builder.Property(x => x.ServiceDescription)
                .IsRequired(); // Ensures the field is not nullable

            // Configure the Picture property to be required
            builder.Property(x => x.Picture)
                .IsRequired(); // Ensures the field is not nullable
        }
    }
}
