//using Elux.Domain.Entities;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;

//namespace Elux.Dal.Data.Configurations
//{
//    public class CartDraftItemConfiguration : IEntityTypeConfiguration<CartDraftItem>
//    {
//        public void Configure(EntityTypeBuilder<CartDraftItem> builder)
//        {
//            builder.HasKey(x => x.Id);

//            builder.Property(x => x.Id)
//                .IsRequired()
//                .ValueGeneratedOnAdd();

//            //builder.Property(x => x.Services)
//            //    .IsRequired()
//            //    .HasMaxLength(3);

//            builder.Property(x => x.TotalPrice)
//                .IsRequired();
//            /////Greater than 0
//        }
//    }
//}
