using System.ComponentModel.DataAnnotations;


namespace perfectPixelApi.DTO
{
    public class SubmittedImageDTO
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public byte Month { get; set; }
        [Required]
        public byte[] Image { get; set; }
    }
}
