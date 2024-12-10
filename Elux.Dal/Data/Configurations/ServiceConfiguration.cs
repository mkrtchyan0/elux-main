//using Elux.Domain.Entities;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;

//namespace Elux.Dal.Data.Configurations
//{
//    // Configuration for the Service entity
//    public class ServiceConfiguration : IEntityTypeConfiguration<Service>
//    {
//        public void Configure(EntityTypeBuilder<Service> builder)
//        {
//            // Set the primary key for the Service entity
//            builder.HasKey(x => x.Id);

//            // Uncomment the following to configure a relationship with the ServiceGroup entity
//            // This code is commented out, but it configures a one-to-many relationship
//            // where each service belongs to one ServiceGroup, but a ServiceGroup can have many Services.
//            // builder.HasOne(service => service.ServiceGroup)
//            //     .WithMany(group => group.Services)
//            //     .HasForeignKey(service => service.ServiceGroupId)
//            //     .IsRequired();

//            // Configure the Id property to be required and auto-generated
//            builder.Property(x => x.Id)
//                .IsRequired() // Ensures the field is not nullable
//                .ValueGeneratedOnAdd(); // Auto-generates the value when a new record is created

//            // Configure the ServiceName property to be required with a max length of 256 characters
//            builder.Property(x => x.ServiceName)
//                .IsRequired() // Ensures the field is not nullable
//                .HasMaxLength(256); // Limits the length of the ServiceName to 256 characters

//            // Configure the Price property to be required
//            builder.Property(x => x.Price)
//                .IsRequired(); // Ensures the field is not nullable

//            // Configure the Duration property to be required
//            builder.Property(x => x.Duration)
//                .IsRequired(); // Ensures the field is not nullable
//        }
//    }
//}
