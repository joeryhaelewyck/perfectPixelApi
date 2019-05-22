using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace perfectPixelApi.Repositories
{
    public class SubmittedImage
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
        public byte? Averagescore { get; set; }
        [Column("IMAGE", TypeName = "image")]
        public byte[] Image { get; set; }
        [Column("VOTER")]
        public string Creator { get; set; }

        public SubmittedImage() { }
        public SubmittedImage(string name, byte month, byte[] image, string voter)
        {
            Name = name;
            Month = month;
            Image = image;
            Creator = voter;
        }
    }
}
