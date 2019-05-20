using System.Collections.Generic;

namespace perfectPixelApi.Model
{
    public interface ISubmittedImageRepository
    {
        SubmittedImage GetById(long id);
        IEnumerable<SubmittedImage> GetByName(string name);
        IEnumerable<SubmittedImage> GetAll();
        IEnumerable<SubmittedImage> GetImagesByMonth(int month);
        SubmittedImage GetImageByHighScoreByMonth(int month);
        void Add(SubmittedImage image);
        void Delete(SubmittedImage image);
        void Update(SubmittedImage image);
        void SaveChanges();
    }
}
