using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace perfectPixelApi.DTOs
{
    public class ScoreGetDTO
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public int IdSubmittedImage { get; set; }
        [Required]
        public int ImageScore { get; set; }
        [Required]
        public string Voter { get; set; }
    }
}
