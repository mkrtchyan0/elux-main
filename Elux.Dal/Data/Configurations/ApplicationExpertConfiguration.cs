//using Elux.Domain.Entities;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;

//namespace AesCredit.Infrastructure.Data.Configurations
//{
//    public class ApplicationExpertConfiguration : IEntityTypeConfiguration<ApplicationExpert>
//    {
//        public void Configure(EntityTypeBuilder<ApplicationExpert> builder)
//        {
//            // Define the primary key for the Expert entity
//            builder.HasKey(c => c.Id);

//            // Configure the Id property to be required and auto-generated
//            builder.Property(p => p.Id)
//                .IsRequired()
//                .ValueGeneratedOnAdd();

//            // Configure the Description property (required, max length 2048 characters)
//            builder.Property(c => c.Description)
//                .IsRequired()
//                .HasMaxLength(2048);

//            // Configure the Profession property (required, max length 64 characters)
//            builder.Property(c => c.Proffesion)
//                .IsRequired()
//                .HasMaxLength(64);

//            // Configure the FirstName property (required, max length 32 characters)
//            builder.Property(c => c.FirstName)
//                .IsRequired()
//                .HasMaxLength(32);

//            // If it's a collection, you will need to configure it differently:
//            // builder.Property(c => c.Certificate)
//            //     .IsRequired()
//            //     .HasMaxLength(2024)
//            //     .HasColumnType("character varying(2024)");

//            // builder.HasMany(c => c.Skills)
//            //     .WithOne() // Specify the relationship, if applicable
//            //     .HasForeignKey(c => c.ExpertId); // Adjust as needed based on your relationship

//            // builder.Property(c => c.Deleted)
//            //     .IsRequired()
//            //     .HasColumnType("bool");

//            // builder.Property(c => c.IsActive)
//            //     .IsRequired()
//            //     .HasColumnType("bool");
//        }
//    }
//}
