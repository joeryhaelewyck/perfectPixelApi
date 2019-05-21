using System.ComponentModel.DataAnnotations;

namespace perfectPixelApi.DTO
{
    public class ScorePatchDTO
    {
        [Required]
        public int ImageScore { get; set; }
    }
}
