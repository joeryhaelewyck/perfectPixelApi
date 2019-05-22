using perfectPixelApi.DTOs;
using System.Collections.Generic;

namespace perfectPixelApi.Services
{
    public interface ISubmittedImageService
    {
        ImageGetDTO GetImageById(int id);
        ImageGetDTO GetImageByHighScoreByMonth(byte month);
        ImageGetDTO GetImageByVoterByMonth(string mail, byte month);
       
        IEnumerable<ImageGetDTO> GetAll();
        IEnumerable<ImageGetDTO> GetImagesByName(string name);
        IEnumerable<ImageGetDTO> GetImagesByMonth(byte month);
  
        ImageGetDTO Add(ImagePutDTO scoreDTO);
        ImageGetDTO Delete(int id);
        ImageGetDTO Update(int id, ImagePutDTO imageUpdate);
        ImageGetDTO ApplyPatch(int id, ImagePatchDTO imagePatch);
    }
}
