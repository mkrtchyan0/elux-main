using Elux.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Elux.Dal.Data.Configurations
{
    // Configuration for the BookServiceItem entity
    public class BookServiceItemConfiguration : IEntityTypeConfiguration<BookServiceItem>
    {
        public void Configure(EntityTypeBuilder<BookServiceItem> builder)
        {
            // Set the primary key for the BookServiceItem entity
            builder.HasKey(x => x.Id);

            // Configure the Id property to be required and auto-generated
            builder.Property(x => x.Id)
                .IsRequired() // Ensure the field cannot be null
                .ValueGeneratedOnAdd(); // Automatically generate the value when a new record is added

            //builder.HasOne<CartDraftItem>(x => x.CartDraftItem)
            //    .WithMany(x => x.BookItems);


            // Configure the DraftId property to be required
            builder.Property(x => x.CartId)
                .IsRequired(); // Ensure the field is required

            // Configure the ExpertsId property to be required
            builder.Property(x => x.ExpertId)
                .IsRequired(); // Ensure the field is required

            // Configure the SubServiceId property to be required
            builder.Property(x => x.ServiceIds)
                .IsRequired(); // Ensure the field is required

            // Configure the TotalPrice property to have a decimal type
            builder.Property(x => x.TotalPrice)
                .HasColumnType("decimal(18,2)") // Correctly specifying the decimal type with precision and scale
                .IsRequired(); // Ensure the field is required

            // Configure the ServiceDate property to be required
            builder.Property(x => x.ServiceDate)
                .IsRequired(); // Ensure the field is required

            // Configure the ServiceDuration property to be required
            builder.Property(x => x.ServiceDuration)
                .IsRequired(); // Ensure the field is required
        }
    }
}
