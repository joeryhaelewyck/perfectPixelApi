
using System.ComponentModel.DataAnnotations;

namespace perfectPixelApi.DTOs
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
