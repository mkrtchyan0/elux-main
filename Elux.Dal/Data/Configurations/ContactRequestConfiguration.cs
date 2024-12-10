//using Elux.Domain.Entities;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;

//namespace Elux.Dal.Data.Configurations
//{
//    // Configuration for the ContactRequest entity
//    public class ContactRequestConfiguration : IEntityTypeConfiguration<ContactRequest>
//    {
//        public void Configure(EntityTypeBuilder<ContactRequest> builder)
//        {
//            // Set the primary key for the ContactRequest entity
//            builder.HasKey(x => x.Id);

//            // Configure the Id property to be required and auto-generated
//            builder.Property(x => x.Id)
//                .IsRequired() // Ensures the field is not nullable
//                .ValueGeneratedOnAdd(); // Auto-generates the value when a new record is created

//            // Configure the EmailAddress property to be required with a max length of 128 characters
//            builder.Property(x => x.EmailAddress)
//                .IsRequired() // Ensures the field is not nullable
//                .HasMaxLength(128); // Limits the length of the email to 128 characters

//            // Configure the PhoneNumber property to be required with a max length of 64 characters
//            builder.Property(x => x.PhoneNumber)
//                .IsRequired() // Ensures the field is not nullable
//                .HasMaxLength(64); // Limits the length of the phone number to 64 characters

//            // Configure the YourMessage property to be required with a max length of 1024 characters
//            builder.Property(x => x.YourMessage)
//                .IsRequired() // Ensures the field is not nullable
//                .HasMaxLength(1024); // Limits the length of the message to 1024 characters

//            // Configure the FullName property to be required with a max length of 64 characters
//            builder.Property(x => x.FullName)
//                .IsRequired() // Ensures the field is not nullable
//                .HasMaxLength(64); // Limits the length of the full name to 64 characters
//        }
//    }
//}

