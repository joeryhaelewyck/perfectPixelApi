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
        public static Builder GetBuilder()
        {
            return new Builder();
        }

        public class Builder
        {
            private readonly SubmittedImage _image = new SubmittedImage();

            public Builder withId(int id)
            {
                _image.Id = id;
                return this;
            }

            public Builder withName(string name)
            {
                _image.Name = name;
                return this;
            }

            public Builder withMonth(byte month)
            {
                _image.Month = month;
                return this;
            }

            public Builder withAverageScore(byte averageScore)
            {
                _image.Averagescore = averageScore;
                return this;
            }
            public Builder withImage(byte[] image)
            {
                _image.Image = image;
                return this;
            }
            public Builder withCreator(string creator)
            {
                _image.Creator = creator;
                return this;
            }
            public SubmittedImage Build()
            {
                return _image;
            }
        }

    }
}
