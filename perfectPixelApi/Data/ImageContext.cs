using Microsoft.EntityFrameworkCore;
using perfectPixelApi.Data.Mappers;
using perfectPixelApi.Models;

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

            modelBuilder.Entity<SubmittedImage>().HasData(
                createImage(1, 4, "EersteImageApril", new byte[] { 0x20, 0x20 }, 5, "lindsay@hotmail.com" ),
                createImage(2, 4, "TweedeImageApril", new byte[] { 0x20, 0x20 }, 3, "noukie@hotmail.com"),
                createImage(3, 4, "DerdeImageApril", new byte[] { 0x20, 0x20 }, 3, "slam@hotmail.com"),
                createImage(4, 5, "EersteImageMei", new byte[] { 0x20, 0x20 }, 0, "joery@hotmail.com"),
                createImage(5, 5, "EersteImageMei", new byte[] { 0x20, 0x20 }, 0, "davy@hotmail.com"),
                createImage(6, 5, "EersteImageMei", new byte[] { 0x20, 0x20 }, 0, "tai@hotmail.com")
                );

            modelBuilder.Entity<Score>().HasData(
                createScore(1, 1, 5, "joery@hotmail.com"),
                createScore(2, 2, 6, "joery@hotmail.com"),
                createScore(3, 3, 7, "joery@hotmail.com"),
                createScore(4, 1, 8, "joery@hotmail.com"),
                createScore(5, 2, 2, "joery@hotmail.com"),
                createScore(6, 3, 9, "joery@hotmail.com"),
                createScore(7, 1, 1, "joery@hotmail.com"),
                createScore(8, 2, 1, "joery@hotmail.com"),
                createScore(9, 3, 2, "joery@hotmail.com")
                );
        }
        public DbSet<SubmittedImage> Images { get; set; }
        public DbSet<Score> Scores { get; set; }

        private Score createScore(int id, int submittedImageId, int imageScore, string voter)
        {
            return Score.GetBuilder()
                .withId(id)
                .withSubmittedImageId(submittedImageId)
                .withImageScore(imageScore)
                .withVoter(voter)
                .Build();
        }
        private SubmittedImage createImage(int id,  byte month, string name, byte[] image, byte averageScore,  string creator)
        {
            return SubmittedImage.GetBuilder()
                .withId(id)
                .withName(name)
                .withMonth(month)
                .withAverageScore(averageScore)
                .withImage(image)
                .withCreator(creator)
                .Build();
        }
    }
}
