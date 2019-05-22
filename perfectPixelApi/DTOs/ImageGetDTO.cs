using System.ComponentModel.DataAnnotations;

namespace perfectPixelApi.DTOs
{
    public class ImageGetDTO
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public byte Month { get; set; }
        [Required]
        public byte AverageScore { get; set; }
        [Required]
        public byte[] Image { get; set; }
        [Required]
        public string Creator { get; set; }

    }
}
