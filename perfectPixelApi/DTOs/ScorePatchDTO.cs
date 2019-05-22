using System.ComponentModel.DataAnnotations;

namespace perfectPixelApi.DTOs
{
    public class ScorePatchDTO
    {
        [Required]
        public int ImageScore { get; set; }
    }
}
