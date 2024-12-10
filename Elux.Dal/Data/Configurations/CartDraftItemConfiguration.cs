//using Elux.Domain.Entities;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;

//namespace Elux.Dal.Data.Configurations
//{
//    // Configuration for the CartDraftItem entity
//    public class CartDraftItemConfiguration : IEntityTypeConfiguration<CartDraftItem>
//    {
//        public void Configure(EntityTypeBuilder<CartDraftItem> builder)
//        {
//            // Set the primary key for the CartDraftItem entity
//            builder.HasKey(x => x.Id);

//            // Configure the Id property to be required and auto-generated
//            builder.Property(x => x.Id)
//                .IsRequired() // Ensures the field is not nullable
//                .ValueGeneratedOnAdd(); // Auto-generates the value when a new record is created

//            // Configure the Services property to be required and set a maximum length of 3
//            builder.Property(x => x.Services)
//                .IsRequired() // Ensures the field is not nullable
//                .HasMaxLength(3); // Limits the list to a maximum of 3 items

//            // Configure the TotalPrice property to be required
//            builder.Property(x => x.TotalPrice)
//                .IsRequired(); // Ensures the field is not nullable
//        }
//    }
//}
