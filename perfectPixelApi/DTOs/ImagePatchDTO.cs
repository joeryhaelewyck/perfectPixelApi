using System.ComponentModel.DataAnnotations;

namespace perfectPixelApi.DTOs
{
    public class ImagePatchDTO
    {
        [Required]
        public string Name { get; set; }
        public byte[] Image { get; set; }
    }
}
