using System.Collections.Generic;
using perfectPixelApi.DTOs;

namespace perfectPixelApi.Repositories
{
    public interface IScoreRepository
    {
        Score GetById(int id);
        Score ApplyPatch(Score currentScore, ScorePatchDTO scorePatch);
        Score GetByImageIdAndVoter(int imageId, string voter);
        IEnumerable<Score> GetByVoter(string name);
        IEnumerable<Score> GetAll();
        IEnumerable<Score> GetByImageId(int id);
        void Add(Score score);
        void SaveChanges();
        
    }
}

