
using System.ComponentModel.DataAnnotations;

namespace perfectPixelApi.DTO
{
    public class ScoreDTO
    {
        [Required]
        public int IdSubmittedImage {get; set;}
        [Required]
        public int ImageScore { get; set; }
        [Required]
        public string Voter { get; set; }
    }
}
