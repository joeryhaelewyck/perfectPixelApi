using perfectPixelApi.DTOs;
using perfectPixelApi.Models;

namespace perfectPixelApi.Mappers
{
    public class ImageMapper
    {
        public static ImagePutDTO toPutDto(SubmittedImage submittedImage)
        {
            ImagePutDTO dto = new ImagePutDTO();
            dto.Name = submittedImage.Name;
            dto.Month = submittedImage.Month;
            dto.Image = submittedImage.Image;
            dto.Creator = submittedImage.Creator;
            return dto;
        }
        public static ImageGetDTO toGetDto(SubmittedImage submittedImage)
        {
            ImageGetDTO dto = new ImageGetDTO();
            dto.Id = submittedImage.Id;
            dto.Name = submittedImage.Name;
            dto.Month = submittedImage.Month;
            dto.Image = submittedImage.Image;
            dto.AverageScore = submittedImage.Averagescore;
            dto.Creator = submittedImage.Creator;
            return dto;
        }
        public static SubmittedImage toSubmittedImage(ImagePutDTO dto)
        {
            SubmittedImage image = new SubmittedImage.Builder()
                 .withName(dto.Name)
                 .withMonth(dto.Month)
                 .withImage(dto.Image)
                 .withCreator(dto.Creator)
                 .Build();
            return image;
        }
    }
}
