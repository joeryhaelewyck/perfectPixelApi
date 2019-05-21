using System.Collections.Generic;
using perfectPixelApi.DTO;

namespace perfectPixelApi.services
{
    public interface IScoreService
    {
        IEnumerable<ScoreDTO> GetAll();
    }
}