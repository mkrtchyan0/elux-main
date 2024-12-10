//using Elux.Domain.Entities;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;

//namespace Elux.Dal.Data.Configurations
//{
//    // Configuration for the Skill entity
//    public class SkillConfiguration : IEntityTypeConfiguration<Skill>
//    {
//        public void Configure(EntityTypeBuilder<Skill> builder)
//        {
//            // Set the primary key for the Skill entity
//            builder.HasKey(x => x.Id);

//            // Configure the Id property to be required and auto-generated
//            builder.Property(x => x.Id)
//                .IsRequired() // Ensures the field is not nullable
//                .ValueGeneratedOnAdd(); // Auto-generates the value when a new record is created

//            // Configure the SkillName property to be required with a maximum length of 64 characters
//            builder.Property(x => x.SkillName)
//                .IsRequired() // Ensures the field is not nullable
//                .HasMaxLength(64); // Sets the maximum length for the SkillName property
//        }
//    }
//}

