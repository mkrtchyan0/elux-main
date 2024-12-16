using Elux.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Elux.Dal.Data.Configurations
{
    public class BookingConfiguration : IEntityTypeConfiguration<Booking>
    {
        public void Configure(EntityTypeBuilder<Booking> builder)
        {
            builder.HasKey(b => b.Id);

            builder.Property(b => b.Id)
                .ValueGeneratedOnAdd()
                .HasColumnType<Guid>(null);

            builder.Property(b => b.ExpertId)
                .IsRequired()
                .HasColumnType<Guid>(null);

            builder.Property(b => b.DateTime)
                    .IsRequired()
                    .HasColumnType<DateTime>(null);

            builder.Property(b => b.StartingTime)
                    .IsRequired()
                    .HasColumnType<int>(null);

            builder.Property(b => b.EndingTime)
                    .IsRequired()
                    .HasColumnType<int>(null);
        }
    }
}
