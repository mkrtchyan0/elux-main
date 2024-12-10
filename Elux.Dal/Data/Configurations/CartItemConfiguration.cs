//using Elux.Domain.Entities;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;

//namespace Elux.Dal.Data.Configurations
//{
//    // Configuration for the CartItem entity
//    public class CartItemConfiguration : IEntityTypeConfiguration<CartItem>
//    {
//        public void Configure(EntityTypeBuilder<CartItem> builder)
//        {
//            // Set the primary key for the CartItem entity
//            builder.HasKey(x => x.Id);

//            // Configure the Id property to be required and auto-generated
//            builder.Property(x => x.Id)
//                .IsRequired() // Ensures the field is not nullable
//                .ValueGeneratedOnAdd(); // Auto-generates the value when a new record is created

//            // Configure the Services property to be required and set a maximum length of 3
//            builder.Property(x => x.Services)
//                .IsRequired() // Ensures the field is not nullable
//                .HasMaxLength(3); // Limits the list to a maximum of 3 items
//        }
//    }
//}

