using System.Collections.Generic;
using perfectPixelApi.DTOs;
using perfectPixelApi.Repositories;

namespace perfectPixelApi.Services
{
    public interface IScoreService
    {
        IEnumerable<ScoreDTO> GetAll();
        Score GetById(int id);
        IEnumerable<Score> GetByImageId(int imageId);
        IEnumerable<Score> GetByVoter(string email);
        Score GetByImageIdAndVoter(int idSubmittedImage, string voter);
        void Add(Score score);
        void SaveChanges();
        Score ApplyPatch(Score currentScore, ScorePatchDTO scorePatch);
    }
}