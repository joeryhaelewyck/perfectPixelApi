using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using perfectPixelApi.Models;

namespace perfectPixelApi.Data.Mappers
{
    public class ImageConfiguration : IEntityTypeConfiguration<SubmittedImage>
    {
        public void Configure(EntityTypeBuilder<SubmittedImage> builder)
        {
            //Table name
            builder.ToTable("SubmittedImage");
            //Primary Key
            builder.HasKey(I => I.Id);
            //Properties
            builder.Property(I => I.Name)
                .HasColumnName("NAME")
                .IsRequired();
            builder.Property(I => I.Month)
                .HasColumnName("MONTH")
                .IsRequired();
            builder.Property(I => I.Averagescore)
                .HasColumnName("AVERAGESCORE");
            builder.Property(I => I.Image)
                .HasColumnName("IMAGE");
            builder.Property(I => I.Creator)
               .HasColumnName("VOTER");
        }
    }
}
