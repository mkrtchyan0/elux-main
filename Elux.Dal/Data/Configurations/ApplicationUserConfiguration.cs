//using Elux.Domain.Entities;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;

//namespace Elux.Dal.Data.Configurations
//{
//    // Configuration for the ApplicationUser entity
//    public class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
//    {
//        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
//        {
//            // Set the primary key for the ApplicationUser entity
//            builder.HasKey(x => x.Id);

//            // Configure the Id property to be required and auto-generated
//            builder.Property(x => x.Id)
//                .IsRequired() // Ensure this field cannot be null
//                .ValueGeneratedOnAdd(); // Automatically generate the value when a new record is added

//            // Configure the FirstName property
//            builder.Property(x => x.FirstName)
//                .IsRequired() // Ensure the field is required (cannot be null)
//                .HasMaxLength(32); // Set the maximum length of the field to 32 characters

//            // Configure the LastName property
//            builder.Property(x => x.LastName)
//                .IsRequired() // Ensure the field is required
//                .HasMaxLength(32); // Set the maximum length of the field to 32 characters

//            // Configure the IsDeleted property with a default value of false
//            builder.Property(x => x.IsDeleted)
//                .IsRequired() // Ensure the field is required
//                .HasDefaultValue(false); // Default value for this field is false

//            // Configure the UserName property
//            builder.Property(x => x.UserName)
//                .IsRequired() // Ensure the field is required
//                .HasMaxLength(256); // Set the maximum length of the field to 256 characters

//            // Configure the Email property
//            builder.Property(x => x.Email)
//                .IsRequired() // Ensure the field is required
//                .HasMaxLength(256); // Set the maximum length of the field to 256 characters
//        }
//    }
//}
