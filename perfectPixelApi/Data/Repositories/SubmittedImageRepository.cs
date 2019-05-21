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
            _images.Add(image);
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

        public SubmittedImage GetById(int id)
        {
            return _images.SingleOrDefault(i => i.Id == id);
        }

        public IEnumerable<SubmittedImage> GetByName(string name)
        {
            return _images.Where(i => i.Name == name);
        }

        public SubmittedImage GetImageByHighScoreByMonth(byte month)
        {
            var images = this.GetImagesByMonth(month);
            return images.OrderByDescending(i => i.Averagescore).First();
        }

        public IEnumerable<SubmittedImage> GetImagesByMonth(byte month)
        {
            return _images.Where(i => i.Month == month).AsQueryable();
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }

        public void Update(SubmittedImage image)
        {
            throw new System.NotImplementedException();
        }
        public int GetNewID()
        {
            int id = _images.OrderByDescending(i => i.Id).Select(i => i.Id).First();
            return id + 1;
        }
    }
}
