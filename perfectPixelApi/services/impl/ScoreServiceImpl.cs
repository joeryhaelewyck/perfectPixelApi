using System.Collections.Generic;
using System.Linq;
using perfectPixelApi.DTO;
using perfectPixelApi.mappers;
using perfectPixelApi.Model;

namespace perfectPixelApi.services.impl
{
    public class ScoreServiceImpl : IScoreService
    {
        private readonly IScoreRepository _scoreRepository;

        public ScoreServiceImpl(IScoreRepository scoreRepository)
        {
            _scoreRepository = scoreRepository;
        }


        public IEnumerable<ScoreDTO> GetAll()
        {
            return _scoreRepository.GetAll().Select(score => ScoreMapper.toDto(score));
        }
    }
}