using System.ComponentModel.DataAnnotations;


namespace perfectPixelApi.DTOs
{
    public class SubmittedImageDTO
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public byte Month { get; set; }
        public byte[] Image { get; set; }
        [Required]
        public string Voter { get; set; }
    }
}
