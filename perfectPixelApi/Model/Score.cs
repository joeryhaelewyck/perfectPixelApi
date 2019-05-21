using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace perfectPixelApi.Model
{
    public partial class Score
    {
        [Column("ID")]
        public int Id { get; set; }
        [Column("IDSUBMITTEDIMAGE")]
        public int Idsubmittedimage { get; set; }
        [Column("IMAGESCORE")]
        public int ImageScore { get; set; }
        [Required]
        [Column("VOTER")]
        [StringLength(50)]
        public string Voter { get; set; }

    }
}
