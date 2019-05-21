using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace perfectPixelApi.Model
{
    public class Score
    {
        [Column("ID")]
        public int Id { get; private set; }
        [Column("IDSUBMITTEDIMAGE")]
        public int IdSubmittedImage { get; private set; }
        [Column("IMAGESCORE")]
        public int ImageScore { get; private set; }
        [Required]
        [Column("VOTER")]
        [StringLength(50)]
        public string Voter { get; private set; }
       
        public Score() { }
        
        public static Builder GetBuilder()
        {
            return new Builder();
        }
        
        public class Builder
        {
            private readonly  Score _score = new Score();

            public Builder withId(int id)
            {
                _score.Id = id;
                return this;
            }

            public Builder withSubmittedImageId(int submittedImageId)
            {
                _score.IdSubmittedImage = submittedImageId;
                return this;
            }

            public Builder withImageScore(int imageScore)
            {
                _score.ImageScore = imageScore;
                return this;
            }

            public Builder withVoter(string voter)
            {
                _score.Voter = voter;
                return this;
            }

            public Score Build()
            {
                return _score;
            }
        }
        
    }
}
