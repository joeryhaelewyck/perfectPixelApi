using System.Collections.Generic;

namespace perfectPixelApi.Model
{
    public interface ISubmittedImageRepository
    {
        SubmittedImage GetById(int id);
        SubmittedImage GetImageByHighScoreByMonth(byte month);
        SubmittedImage GetImageByVoterByMonth(string mail, byte month);
        IEnumerable<SubmittedImage> GetByName(string name);
        IEnumerable<SubmittedImage> GetAll();
        IEnumerable<SubmittedImage> GetImagesByMonth(byte month);
        IEnumerable<SubmittedImage> GetImageByVoter(string mail);
        
        void Add(SubmittedImage image);
        void Delete(SubmittedImage image);
        void Update(SubmittedImage image);
        void SaveChanges();
        int GetNewID();
    }
}
