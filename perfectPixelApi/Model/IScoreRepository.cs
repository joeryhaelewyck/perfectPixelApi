using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using perfectPixelApi.DTO;

namespace perfectPixelApi.Model
{
    public interface IScoreRepository
    {
        Score GetById(int id);
        Score ApplyPatch(Score currentScore, ScorePatchDTO scorePatch);
        IEnumerable<Score> GetByVoter(string name);
        IEnumerable<Score> GetAll();
        IEnumerable<Score> GetByImageId(int id);
        void Add(Score score);
        void SaveChanges();
        int GetNewID();
        
    }
}

