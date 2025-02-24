﻿using Elux.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

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

            builder.Property(b => b.Date)
                .HasConversion<DateOnlyConverter>()
                .HasColumnType("date"); 

            builder.Property(b => b.Start)
                .HasConversion<TimeOnlyConverter>()
                .HasColumnType("time"); 

            builder.Property(b => b.End)
                .HasConversion<TimeOnlyConverter>()
                .HasColumnType("time");
        }
    }

    public class DateOnlyConverter : ValueConverter<DateOnly, DateTime>
    {
        public DateOnlyConverter() : base(
            dateOnly => DateTime.SpecifyKind(dateOnly.ToDateTime(TimeOnly.MinValue), DateTimeKind.Utc),
            dateTime => DateOnly.FromDateTime(dateTime))
        { }
    }

    public class TimeOnlyConverter : ValueConverter<TimeOnly, TimeSpan>
    {
        public TimeOnlyConverter() : base(timeOnly => timeOnly.ToTimeSpan(),timeSpan => TimeOnly.FromTimeSpan(timeSpan)){ }
    }

}
