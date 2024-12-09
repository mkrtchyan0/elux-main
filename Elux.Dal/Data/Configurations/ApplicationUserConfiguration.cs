//using Elux.Domain.Entities;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;

//namespace Elux.Dal.Data.Configurations
//{
//    public class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
//    {
//        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
//        {
//            builder.HasKey(x => x.Id);

//            builder.Property(x => x.Id)
//                .IsRequired()
//                .ValueGeneratedOnAdd();

//            builder.Property(x => x.FirstName)
//                .IsRequired()
//                .HasMaxLength(32);

//            builder.Property(x => x.LastName)
//                .IsRequired()
//                .HasMaxLength(32);

//            builder.Property(x => x.IsDeleted)
//                .IsRequired()
//                .HasDefaultValue(false);
//        }
//    }
//}
