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
//    public class BookServiceItemConfiguration : IEntityTypeConfiguration<BookServiceItem>
//    {
//        public void Configure(EntityTypeBuilder<BookServiceItem> builder)
//        {
//            builder.HasKey(x => x.Id);

//            builder.Property(x => x.Id)
//                .IsRequired()
//                .ValueGeneratedOnAdd();

//            builder.Property(x => x.DraftId)
//                .IsRequired();

//            builder.Property(x => x.ExpertsId)
//                .IsRequired();

//            builder.Property(x => x.SubServiceId)
//                .IsRequired();

//            builder.Property(x => x.TotalPrice)
//                .HasColumnType<Decimal>(null)
//                .IsRequired();
                

//            builder.Property(x => x.ServiceDate)
//                .IsRequired();

//            builder.Property(x => x.ServiceDuration)
//                .IsRequired();
//        }
//    }
//}
