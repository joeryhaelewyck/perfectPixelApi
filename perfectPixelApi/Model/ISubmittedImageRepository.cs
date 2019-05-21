using System.Collections.Generic;

namespace perfectPixelApi.Model
{
    public interface ISubmittedImageRepository
    {
        SubmittedImage GetById(int id);
        IEnumerable<SubmittedImage> GetByName(string name);
        IEnumerable<SubmittedImage> GetAll();
        IEnumerable<SubmittedImage> GetImagesByMonth(byte month);
        SubmittedImage GetImageByHighScoreByMonth(byte month);
        void Add(SubmittedImage image);
        void Delete(SubmittedImage image);
        void Update(SubmittedImage image);
        void SaveChanges();
        int GetNewID();
    }
}
