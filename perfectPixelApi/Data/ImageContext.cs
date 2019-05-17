using Microsoft.EntityFrameworkCore;
using perfectPixelApi.Models;

namespace perfectPixelApi.Data
{
    public class ImageContext : DbContext
    {
        public ImageContext(DbContextOptions<ImageContext> options) : base(options) { }
        public DbSet<MonthImage> MonthImages { get; set; }
    }
}
