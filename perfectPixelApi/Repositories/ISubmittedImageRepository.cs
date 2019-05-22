using System.Collections.Generic;
using perfectPixelApi.DTOs;

namespace perfectPixelApi.Repositories
{
    public interface ISubmittedImageRepository
    {
        
        SubmittedImage GetById(int id);
        SubmittedImage GetImageByHighScoreByMonth(byte month);
        SubmittedImage GetImageByVoterByMonth(string mail, byte month);
        SubmittedImage ApplyPatch(SubmittedImage submittedImage, ImagePatchDTO imagePatch);
        IEnumerable<SubmittedImage> GetByName(string name);
        IEnumerable<SubmittedImage> GetAll();
        IEnumerable<SubmittedImage> GetImagesByMonth(byte month);
        IEnumerable<SubmittedImage> GetImageByVoter(string mail);

        int GetNewID();
        void Add(SubmittedImage image);
        void Delete(SubmittedImage image);
        void Update(SubmittedImage image);
        void SaveChanges();
        
    }
}
