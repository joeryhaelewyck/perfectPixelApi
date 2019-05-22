using perfectPixelApi.DTOs;
using perfectPixelApi.Repositories;

namespace perfectPixelApi.Mappers
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