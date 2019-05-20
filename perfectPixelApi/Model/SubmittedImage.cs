using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace perfectPixelApi.Model
{
    public partial class SubmittedImage
    {
        [Column("ID")]
        public int Id { get; set; }
        [Required]
        [Column("NAME")]
        [StringLength(50)]
        public string Name { get; set; }
        [Column("MONTH")]
        public byte Month { get; set; }
        [Column("AVERAGESCORE")]
        public byte? AverageScore { get; set; }
        [Column("IMAGE", TypeName = "image")]
        public byte[] Image { get; set; }
    }
}
