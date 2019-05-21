using System.ComponentModel.DataAnnotations;

namespace perfectPixelApi.DTO
{
    public class ImagePatchDTO
    {
        [Required]
        public string Name { get; set; }
        public byte[] Image { get; set; }
    }
}
