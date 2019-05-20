using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using perfectPixelApi.Model;

namespace perfectPixelApi.Data.Repositories
{
    public class SubmittedImageRepository : ISubmittedImageRepository
    {
        private readonly ImageContext _dbContext;
        private readonly DbSet<SubmittedImage> _images;

        public SubmittedImageRepository(ImageContext dbContext)
        {
            _dbContext = dbContext;
            _images = dbContext.Images;
        }

        public void Add(SubmittedImage image)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(SubmittedImage image)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<SubmittedImage> GetAll()
        {
            var images = _images.AsQueryable();
            return images.OrderBy(i => i.Name).ToList();
        }

        public SubmittedImage GetById(long id)
        {
            return _images.SingleOrDefault(i => i.Id == id);
        }

        public IEnumerable<SubmittedImage> GetByName(string name)
        {
            return _images.Where(i => i.Name == name);
        }

        public SubmittedImage GetImageByHighScoreByMonth(int month)
        {
            var images = this.GetImagesByMonth(month);
            return images.OrderByDescending(i => i.Score).First();
        }

        public IEnumerable<SubmittedImage> GetImagesByMonth(int month)
        {
            return _images.Where(i => i.Month == month).AsQueryable();
        }

        public void SaveChanges()
        {
            throw new System.NotImplementedException();
        }

        public void Update(SubmittedImage image)
        {
            throw new System.NotImplementedException();
        }
    }
}
