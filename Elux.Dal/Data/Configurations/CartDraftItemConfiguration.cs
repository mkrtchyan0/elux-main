using Elux.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Diagnostics;
using System.Reflection.Emit;

namespace Elux.Dal.Data.Configurations
{
    // Configuration for the CartDraftItem entity
    public class CartDraftItemConfiguration : IEntityTypeConfiguration<CartDraftItem>
    {
        public void Configure(EntityTypeBuilder<CartDraftItem> builder)
        {
            // Set the primary key for the CartDraftItem entity
            builder.HasKey(x => x.Id);

            // Configure the Id property to be required and auto-generated
            builder.Property(x => x.Id)
                .IsRequired() // Ensures the field is not nullable
                .ValueGeneratedOnAdd(); // Auto-generates the value when a new record is created

            // Configure the Services property to be required and set a maximum length of 3
            builder.Ignore(x => x.BookItems);                  


            // Configure the TotalPrice property to be required
            builder.Property(x => x.TotalPrice)
                .IsRequired(); // Ensures the field is not nullable

            //builder
            //   .HasMany<BookServiceItem>(cd => cd.BookItems)
            //   .WithOne(b => b.CartDraftItem)
            //   .HasForeignKey(b => b.Id);           
        }
    }
}
