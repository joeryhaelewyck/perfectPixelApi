using perfectPixelApi.DTOs;
using perfectPixelApi.Repositories;

namespace perfectPixelApi.Mappers
{
    public class ScoreMapper
    {
        public static ScorePutDTO toPutDto(Score score)
        {
            ScorePutDTO dto = new ScorePutDTO();
            dto.ImageScore = score.ImageScore;
            dto.IdSubmittedImage = score.IdSubmittedImage;
            dto.Voter = score.Voter;
            return dto;
        }
        public static ScoreGetDTO toGetDto(Score score)
        {
            ScoreGetDTO dto = new ScoreGetDTO();
            dto.Id = score.Id;
            dto.ImageScore = score.ImageScore;
            dto.IdSubmittedImage = score.IdSubmittedImage;
            dto.Voter = score.Voter;
            return dto;
        }
        public static Score toScore(ScorePutDTO dto)
        {
            Score score = new Score.Builder()
                 .withSubmittedImageId(dto.IdSubmittedImage)
                 .withImageScore(dto.ImageScore)
                 .withVoter(dto.Voter)
                 .Build();
            return score;
        }
    }
}