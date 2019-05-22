using System.Collections.Generic;
using System.Linq;
using perfectPixelApi.DTOs;
using perfectPixelApi.Mappers;
using perfectPixelApi.Repositories;

namespace perfectPixelApi.Services.impl
{
    public class ScoreServiceImpl : IScoreService
    {
        private readonly IScoreRepository _scoreRepository;

        public ScoreServiceImpl(IScoreRepository scoreRepository)
        {
            _scoreRepository = scoreRepository;
        }

        public void Add(Score score)
        {
            _scoreRepository.Add(score);
        }

        public IEnumerable<ScoreDTO> GetAll()
        {
            return _scoreRepository.GetAll().Select(score => ScoreMapper.toDto(score));
        }

        public Score GetById(int id)
        {
            return _scoreRepository.GetById(id);
        }

        public IEnumerable<Score> GetByImageId(int imageId)
        {
            return _scoreRepository.GetByImageId(imageId);
        }

        public Score GetByImageIdAndVoter(int idSubmittedImage, string voter)
        {
            return _scoreRepository.GetByImageIdAndVoter(idSubmittedImage, voter);
        }

        public IEnumerable<Score> GetByVoter(string email)
        {
            return _scoreRepository.GetByVoter(email);
        }

        public void SaveChanges()
        {
            _scoreRepository.SaveChanges();
        }

        public Score ApplyPatch(Score currentScore, ScorePatchDTO scorePatch)
        {
           return _scoreRepository.ApplyPatch(currentScore, scorePatch);
        }
    }
}