namespace perfectPixelApi.Data
{
    public class ImageDataInitializer
    {
        private readonly ImageContext _dbContext;
        public ImageDataInitializer(ImageContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void InitializeData()
        {
            _dbContext.Database.EnsureDeleted();
            _dbContext.Database.EnsureCreated();
            
        }
    }
}
