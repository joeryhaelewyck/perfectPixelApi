using System.ComponentModel.DataAnnotations;
namespace perfectPixelApi.DTOs
{
    public class ScoreGetDTO
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public int IdSubmittedImage { get; set; }
        [Required]
        public int ImageScore { get; set; }
        [Required]
        public string Voter { get; set; }
    }
}
