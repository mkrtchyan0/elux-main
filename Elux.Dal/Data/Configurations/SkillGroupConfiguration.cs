//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;

//namespace Elux.Dal.Data.Configurations
//{
//    // Configuration for the SkillGroup entity
//    public class SkillGroupConfiguration : IEntityTypeConfiguration<SkillGroup>
//    {
//        public void Configure(EntityTypeBuilder<SkillGroup> builder)
//        {
//            // Set the primary key for the SkillGroup entity
//            builder.HasKey(x => x.Id);

//            // Configure the Id property to be required and auto-generated
//            builder.Property(x => x.Id)
//                .IsRequired() // Ensures the field is not nullable
//                .ValueGeneratedOnAdd(); // Auto-generates the value when a new record is created

//            // Configure the GroupName property to be required
//            builder.Property(x => x.GroupName)
//                .IsRequired(); // Ensures the field is not nullable
//        }
//    }
//}

