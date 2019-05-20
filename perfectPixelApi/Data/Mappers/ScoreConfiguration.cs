using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using perfectPixelApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace perfectPixelApi.Data.Mappers
{
    public class ScoreConfiguration : IEntityTypeConfiguration<Score>
    {
        public void Configure(EntityTypeBuilder<Score> builder)
        {
            //Table name
            builder.ToTable("Scores");
            //Primary Key
            builder.HasKey(I => I.Id);
            //Properties
            builder.Property(I => I.Idsubmittedimage)
                .HasColumnName("IDSUBMITTEDIMAGE")
                .IsRequired();
            builder.Property(I => I.ImageScore)
                .HasColumnName("MONTH")
                .IsRequired();
            builder.Property(I => I.Voter)
                .HasColumnName("VOTER")
                .IsRequired();
        }
    }
}
