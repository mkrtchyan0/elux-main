//using Elux.Domain.Entities;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Elux.Dal.Data.Configurations
//{
//    public class ContactRequestConfiguration : IEntityTypeConfiguration<ContactRequest>
//    {
//        public void Configure(EntityTypeBuilder<ContactRequest> builder)
//        {
//            builder.HasKey(x => x.Id);

//            builder.Property(x => x.Id)
//                .IsRequired()
//                .ValueGeneratedOnAdd();

//            builder.Property(x => x.EmailAddress)
//                .IsRequired()
//                .HasMaxLength(128);

//            builder.Property(x => x.PhoneNumber)
//                .IsRequired()
//                .HasMaxLength(64);

//            builder.Property(x => x.YourMessage)
//                .IsRequired()
//                .HasMaxLength(1024);

//            builder.Property(x => x.FullName)
//                .IsRequired()
//                .HasMaxLength(64);
//        }
//    }
//}
