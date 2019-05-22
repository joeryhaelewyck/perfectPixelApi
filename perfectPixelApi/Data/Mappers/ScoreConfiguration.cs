using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using perfectPixelApi.Models;
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
            builder.ToTable("Score");
            //Primary Key
            builder.HasKey(I => I.Id);
            //Properties
            builder.Property(I => I.IdSubmittedImage)
                .HasColumnName("IDSUBMITTEDIMAGE")
                .IsRequired();
            builder.Property(I => I.ImageScore)
                .HasColumnName("IMAGESCORE")
                .IsRequired();
            builder.Property(I => I.Voter)
                .HasColumnName("VOTER")
                .IsRequired();
        }
    }
}
