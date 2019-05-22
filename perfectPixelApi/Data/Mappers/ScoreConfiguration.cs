using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using perfectPixelApi.Models;

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
