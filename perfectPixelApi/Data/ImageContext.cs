using Microsoft.EntityFrameworkCore;
using perfectPixelApi.Data.Mappers;
using perfectPixelApi.Model;
namespace perfectPixelApi.Data
{
    public class ImageContext : DbContext
    {
        public ImageContext(DbContextOptions<ImageContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new ImageConfiguration());
            modelBuilder.ApplyConfiguration(new ScoreConfiguration());

        }
        public DbSet<SubmittedImage> Images { get; set; }
        public DbSet<Score> Scores { get; set; }
    }
}
