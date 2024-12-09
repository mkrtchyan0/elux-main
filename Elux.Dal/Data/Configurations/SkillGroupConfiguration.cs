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
//    public class SkillGroupConfiguration : IEntityTypeConfiguration<SkillGroup>
//    {
//        public void Configure(EntityTypeBuilder<SkillGroup> builder)
//        {
//            builder.HasKey(x => x.Id);

//            builder.Property(x => x.Id)
//                .IsRequired()
//                .ValueGeneratedOnAdd();

//            builder.Property(x => x.GroupName)
//                .IsRequired();
//        }
//    }
//}
