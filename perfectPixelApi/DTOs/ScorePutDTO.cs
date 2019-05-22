
using System.ComponentModel.DataAnnotations;

namespace perfectPixelApi.DTOs
{
    public class ScorePutDTO
    {
        [Required]
        public int IdSubmittedImage {get; set;}
        [Required]
        public int ImageScore { get; set; }
        [Required]
        public string Voter { get; set; }
    }
}
