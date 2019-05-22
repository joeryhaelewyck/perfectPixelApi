using System.Collections.Generic;
using System.Linq;
using perfectPixelApi.DTOs;
using perfectPixelApi.Mappers;
using perfectPixelApi.Models;

namespace perfectPixelApi.Services.Impl
{
    public class SubmittedImageService : ISubmittedImageService
    {
        private readonly ISubmittedImageRepository _submittedImageRepository;
        public SubmittedImageService(ISubmittedImageRepository submittedImageRepository)
        {
            _submittedImageRepository = submittedImageRepository;
        }
      

        

        public IEnumerable<ImageGetDTO> GetAll()
        {
           return _submittedImageRepository.GetAll().Select(image => ImageMapper.toGetDto(image));
        }

        public ImageGetDTO GetImageById(int id)
        {
            return ImageMapper.toGetDto(_submittedImageRepository.GetImageById(id));
        }

        public IEnumerable<ImageGetDTO> GetImagesByName(string name)
        {
            return _submittedImageRepository.GetImagesByName(name).Select(image => ImageMapper.toGetDto(image));
        }

        public ImageGetDTO GetImageByHighScoreByMonth(byte month)
        {
            return ImageMapper.toGetDto(_submittedImageRepository.GetImageByHighScoreByMonth(month));
        }

        public ImageGetDTO GetImageByVoterByMonth(string mail, byte month)
        {
            return ImageMapper.toGetDto(_submittedImageRepository.GetImageByVoterByMonth(mail, month));
        }


        public IEnumerable<ImageGetDTO> GetImagesByMonth(byte month)
        {
            return _submittedImageRepository.GetImagesByMonth(month).Select(image => ImageMapper.toGetDto(image));
        }
        public ImageGetDTO Add(ImagePutDTO scoreDTO)
        {
            SubmittedImage image = ImageMapper.toSubmittedImage(scoreDTO);
            _submittedImageRepository.Add(image);
            _submittedImageRepository.SaveChanges();
            return ImageMapper.toGetDto(image);
        }

        public ImageGetDTO Delete(int id)
        {
            SubmittedImage image = _submittedImageRepository.GetImageById(id);
            _submittedImageRepository.Delete(image);
            _submittedImageRepository.SaveChanges();
            return ImageMapper.toGetDto(image);
        }

        public ImageGetDTO Update(int id, ImagePutDTO imagePutDTO)
        {
            SubmittedImage imageToUpdate = _submittedImageRepository.GetImageById(id);
            imageToUpdate.Name = imagePutDTO.Name;
            imageToUpdate.Month = imagePutDTO.Month;
            imageToUpdate.Image = imagePutDTO.Image;
            imageToUpdate.Creator = imagePutDTO.Creator;
            _submittedImageRepository.Update(imageToUpdate);
            _submittedImageRepository.SaveChanges();
            return ImageMapper.toGetDto(imageToUpdate);
        }
        public ImageGetDTO ApplyPatch(int id, ImagePatchDTO imagePatch)
        {
            SubmittedImage imagePatched = _submittedImageRepository.GetImageById(id);
            imagePatched.Name = imagePatch.Name;
            imagePatched.Image = imagePatch.Image;
            _submittedImageRepository.Update(imagePatched);
            _submittedImageRepository.SaveChanges();
            return ImageMapper.toGetDto(imagePatched);
        }
    }
}
