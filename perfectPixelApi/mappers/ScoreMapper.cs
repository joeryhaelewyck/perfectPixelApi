using perfectPixelApi.DTO;
using perfectPixelApi.Model;

namespace perfectPixelApi.mappers
{
    public class ScoreMapper
    {
        public static ScoreDTO toDto(Score score)
        {
            ScoreDTO dto = new ScoreDTO();
            dto.ImageScore = score.ImageScore;
            dto.IdSubmittedImage = score.IdSubmittedImage;
            dto.Voter = score.Voter;
            return dto;
        }
    }
}