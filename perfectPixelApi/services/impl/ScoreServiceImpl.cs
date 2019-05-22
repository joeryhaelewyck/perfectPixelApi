using System.Collections.Generic;
using System.Linq;
using perfectPixelApi.DTOs;
using perfectPixelApi.Mappers;
using perfectPixelApi.Models;

namespace perfectPixelApi.Services.impl
{
    public class ScoreServiceImpl : IScoreService
    {
        private readonly IScoreRepository _scoreRepository;

        public ScoreServiceImpl(IScoreRepository scoreRepository)
        {
            _scoreRepository = scoreRepository;
        }

        public Score Add(ScorePutDTO scorePutDTO)
        {
            Score score = ScoreMapper.toScore(scorePutDTO);
            _scoreRepository.Add(score);
            _scoreRepository.SaveChanges();
            return score;
        }

        public IEnumerable<ScoreGetDTO> GetAll()
        {
            return _scoreRepository.GetAll().Select(score => ScoreMapper.toGetDto(score));
        }

        public ScoreGetDTO GetById(int id)
        {
            return ScoreMapper.toGetDto(_scoreRepository.GetById(id));
        }

        public IEnumerable<ScoreGetDTO> GetByImageId(int imageId)
        {
            return _scoreRepository.GetByImageId(imageId).Select(score => ScoreMapper.toGetDto(score));
        }

        public ScoreGetDTO GetByImageIdAndVoter(int idSubmittedImage, string voter)
        {
            return ScoreMapper.toGetDto(_scoreRepository.GetByImageIdAndVoter(idSubmittedImage, voter));
        }

        public IEnumerable<ScoreGetDTO> GetByVoter(string email)
        {
            return _scoreRepository.GetByVoter(email).Select(score => ScoreMapper.toGetDto(score));
        }

        public Score ApplyPatch(int id, ScorePatchDTO scorePatch)
        {
            Score currentScore = _scoreRepository.GetById(id);
            currentScore.ImageScore = scorePatch.ImageScore;
            _scoreRepository.Update(currentScore);
            _scoreRepository.SaveChanges();
            return currentScore;
        }
    }
}