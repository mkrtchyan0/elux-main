//using Elux.Domain.Entities;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;

//namespace Elux.Dal.Data.Configurations
//{
//    /// <summary>
//    /// Configures the entity mappings for the ApplicationBlog entity.
//    /// Implements IEntityTypeConfiguration<ApplicationBlog>.
//    /// </summary>
//    public class ApplicationBlogConfiguration : IEntityTypeConfiguration<ApplicationBlog>
//    {
//        /// <summary>
//        /// Configures the entity of type ApplicationBlog.
//        /// </summary>
//        /// <param name="builder">The entity type builder used to configure the entity.</param>
//        public void Configure(EntityTypeBuilder<ApplicationBlog> builder)
//        {
//            // Set the primary key for the ApplicationBlog entity
//            builder.HasKey(x => x.Id);

//            // Configure the Id property to be required and automatically generated
//            builder.Property(x => x.Id)
//                .IsRequired()
//                .ValueGeneratedOnAdd();

//            // Configure the Title property to be required and set its maximum length to 64 characters
//            builder.Property(x => x.Title)
//                .IsRequired()
//                .HasMaxLength(64);

//            // Configure the Description property to be required and set its maximum length to 256 characters
//            builder.Property(x => x.Description)
//                .IsRequired()
//                .HasMaxLength(256);

//            // Configure the ReleaseDate property to be required
//            builder.Property(x => x.ReleaseDate)
//                .IsRequired();

//            // Configure the Picture property to be required
//            builder.Property(x => x.Picture)
//                .IsRequired();
//        }
//    }
//}

