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
//    public class CartItemConfiguration : IEntityTypeConfiguration<CartItem>
//    {
//        public void Configure(EntityTypeBuilder<CartItem> builder)
//        {
//            builder.HasKey(x => x.Id);

//            builder.Property(x => x.Id)
//                .IsRequired()
//                .ValueGeneratedOnAdd();

//            builder.Property(x => x.Services)
//                .IsRequired()
//                .HasMaxLength(3);            
//        }
//    }
//}
