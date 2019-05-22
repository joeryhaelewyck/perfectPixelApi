using System.Collections.Generic;
using perfectPixelApi.DTOs;

namespace perfectPixelApi.Services
{
    public interface IScoreService
    {
        ScoreGetDTO GetById(int id);
        ScoreGetDTO GetByImageIdAndVoter(int idSubmittedImage, string voter);

        IEnumerable<ScoreGetDTO> GetAll();
        IEnumerable<ScoreGetDTO> GetByImageId(int imageId);
        IEnumerable<ScoreGetDTO> GetByVoter(string email);

        ScoreGetDTO Add(ScorePutDTO scoreDTO);
        ScoreGetDTO ApplyPatch(int id, ScorePatchDTO scorePatch);
    }
}