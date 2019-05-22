using Microsoft.EntityFrameworkCore;
using perfectPixelApi.Data.Mappers;
using perfectPixelApi.Repositories;
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
                new SubmittedImage { Id = 1, Month = 4, Name = "EersteImage", Image = new byte[] { 0x20, 0x20 }, Averagescore = 5 ,Creator = "lindsay@hotmail.com" },
                new SubmittedImage { Id = 2, Month = 4, Name = "TweedeImage", Image = new byte[] { 0x20, 0x20, 0x20, 0x20 },Averagescore = 3 , Creator = "noukie@hotmail.com" },
                new SubmittedImage { Id = 3, Month = 4, Name = "DerdeImage", Image = new byte[] { 0x20, 0x20, 0x20, 0x20,0x20 }, Averagescore = 3 ,Creator = "slam@hotmail.com" },
                new SubmittedImage { Id = 4, Month = 5, Name = "EersteImage", Image = new byte[] { 0x20, 0x20 }, Creator = "joery@hotmail.com" },
                new SubmittedImage { Id = 5, Month = 5, Name = "TweedeImage", Image = new byte[] { 0x20, 0x20, 0x20, 0x20 }, Creator = "davy@hotmail.com" },
                new SubmittedImage { Id = 6, Month = 5, Name = "DerdeImage", Image = new byte[] { 0x20, 0x20, 0x20, 0x20, 0x20 }, Creator = "tai@hotmail.com" }
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
    }
}
