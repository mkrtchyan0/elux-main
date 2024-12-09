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

//            builder.Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();

//            builder.Property(c => c.Description)
//                .IsRequired()
//                .HasMaxLength(2048)
//                .HasColumnType<string>(null);

//            builder.Property(c => c.Proffesion)
//                .IsRequired()
//                .HasMaxLength(64)
//                .HasColumnType<string>(null);

//            builder.Property(c => c.FirstName)
//                .IsRequired()
//                .HasMaxLength(32)
//                .HasColumnType<string>(null);

//            //builder.Property(c => c.Certificate)
//            //    .IsRequired()
//            //    .HasMaxLength(2024)
//            //    .HasColumnType("character varying(2024)");

//            //builder.Property(c => c.Skills)
//            //    .()
//            //    .HasMaxLength(32)
//            //    .HasColumnType("character varying(2024)");

//            //builder.Property(c => c.Deleted)
//            //    .IsRequired()
//            //    .HasColumnType("bool");

//            //builder.Property(c => c.IsActive)
//            //    .IsRequired()
//            //    .HasColumnType("bool");
//        }
//    }
//}