//using Elux.Domain.Entities;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;

//namespace Elux.Dal.Data.Configurations
//{
//    public class SkillConfiguration : IEntityTypeConfiguration<Skill>
//    {
//        public void Configure(EntityTypeBuilder<Skill> builder)
//        {
//            builder.HasKey(x => x.Id);
            
//            builder.Property(x => x.Id)
//                .IsRequired()
//                .ValueGeneratedOnAdd();

//            builder.Property(x => x.SkillName)
//                .IsRequired()
//                .HasMaxLength(64);
//        }
//    }
//}
