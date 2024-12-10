//using Elux.Domain.Entities;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;

//namespace Elux.Dal.Data.Configurations
//{
//    // Configuration for the ExpertsWork entity
//    public class ExpertsWorkConfiguration : IEntityTypeConfiguration<ExpertsWork>
//    {
//        public void Configure(EntityTypeBuilder<ExpertsWork> builder)
//        {
//            // Set the primary key for the ExpertsWork entity
//            builder.HasKey(x => x.Id);

//            // Configure the Id property to be required and auto-generated
//            builder.Property(x => x.Id)
//                .IsRequired() // Ensures the field is not nullable
//                .ValueGeneratedOnAdd(); // Auto-generates the value when a new record is created

//            // Configure the WorkName property to be required with a max length of 64 characters
//            builder.Property(x => x.WorkName)
//                .IsRequired() // Ensures the field is not nullable
//                .HasMaxLength(64); // Limits the length of the WorkName to 64 characters
//        }
//    }
//}

