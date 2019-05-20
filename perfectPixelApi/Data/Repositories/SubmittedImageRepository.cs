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
            throw new System.NotImplementedException();
        }

        public SubmittedImage GetByName(string name)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<SubmittedImage> GetImagesByMonth(string month)
        {
            throw new System.NotImplementedException();
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
