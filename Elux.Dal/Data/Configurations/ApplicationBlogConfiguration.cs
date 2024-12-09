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
//    public class ApplicationBlogConfiguration : IEntityTypeConfiguration<ApplicationBlog>
//    {
//        public void Configure(EntityTypeBuilder<ApplicationBlog> builder)
//        {
//            builder.HasKey(x => x.Id);

//            builder.Property(x => x.Id)
//                .IsRequired()
//                .ValueGeneratedOnAdd();

//            builder.Property(x => x.Title)
//                .IsRequired()
//                .HasMaxLength(64);

//            builder.Property(x => x.Description)
//                .IsRequired()
//                .HasMaxLength(256);

//            builder.Property(x => x.ReleaseDate)
//                .IsRequired();

//            builder.Property(x => x.Picture)
//                .IsRequired();
//        }
//    }
//}
