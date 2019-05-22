using System.Collections.Generic;
using perfectPixelApi.DTOs;
using perfectPixelApi.Repositories;

namespace perfectPixelApi.Services
{
    public interface IScoreService
    {
        IEnumerable<ScoreGetDTO> GetAll();
        ScoreGetDTO GetById(int id);
        IEnumerable<ScoreGetDTO> GetByImageId(int imageId);
        IEnumerable<ScoreGetDTO> GetByVoter(string email);
        ScoreGetDTO GetByImageIdAndVoter(int idSubmittedImage, string voter);
        Score Add(ScorePutDTO scoreDTO);
        Score ApplyPatch(int id, ScorePatchDTO scorePatch);
    }
}