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

            modelBuilder.Entity<SubmittedImage>().HasData(
                new SubmittedImage { Id = 1, Month = 4, Name = "EersteImage", Image = new byte[] { 0x20, 0x20 }, Averagescore = 5 ,Creator = "lindsay@hotmail.com" },
                new SubmittedImage { Id = 2, Month = 4, Name = "TweedeImage", Image = new byte[] { 0x20, 0x20, 0x20, 0x20 },Averagescore = 3 , Creator = "noukie@hotmail.com" },
                new SubmittedImage { Id = 3, Month = 4, Name = "DerdeImage", Image = new byte[] { 0x20, 0x20, 0x20, 0x20,0x20 }, Averagescore = 3 ,Creator = "slam@hotmail.com" },
                new SubmittedImage { Id = 4, Month = 5, Name = "EersteImage", Image = new byte[] { 0x20, 0x20 }, Creator = "joery@hotmail.com" },
                new SubmittedImage { Id = 5, Month = 5, Name = "TweedeImage", Image = new byte[] { 0x20, 0x20, 0x20, 0x20 }, Creator = "davy@hotmail.com" },
                new SubmittedImage { Id = 6, Month = 5, Name = "DerdeImage", Image = new byte[] { 0x20, 0x20, 0x20, 0x20, 0x20 }, Creator = "tai@hotmail.com" }
                );

            modelBuilder.Entity<Score>().HasData(
                new Score { Id = 1, IdSubmittedImage = 1, ImageScore = 5, Voter = "joery@hotmail.com" },
                new Score { Id = 2, IdSubmittedImage = 2, ImageScore = 6, Voter = "joery@hotmail.com" },
                new Score { Id = 3, IdSubmittedImage = 3, ImageScore = 7, Voter = "joery@hotmail.com" },
                new Score { Id = 4, IdSubmittedImage = 1, ImageScore = 8, Voter = "davy@hotmail.com" },
                new Score { Id = 5, IdSubmittedImage = 2, ImageScore = 2, Voter = "davy@hotmail.com" },
                new Score { Id = 6, IdSubmittedImage = 3, ImageScore = 9, Voter = "davy@hotmail.com" },
                new Score { Id = 7, IdSubmittedImage = 1, ImageScore = 1, Voter = "tai@hotmail.com" },
                new Score { Id = 8, IdSubmittedImage = 2, ImageScore = 1, Voter = "tai@hotmail.com" },
                new Score { Id = 9, IdSubmittedImage = 3, ImageScore = 2, Voter = "tai@hotmail.com" }
                );
        }
        public DbSet<SubmittedImage> Images { get; set; }
        public DbSet<Score> Scores { get; set; }
    }
}
