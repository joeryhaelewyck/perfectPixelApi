using Microsoft.EntityFrameworkCore;
using perfectPixelApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace perfectPixelApi.Data.Repositories
{
    public class ScoreRepository : IScoreRepository
    {

        private readonly ImageContext _dbContext;
        private readonly DbSet<Score> _scores;

        public ScoreRepository(ImageContext dbContext)
        {
            _dbContext = dbContext;
            _scores = dbContext.Scores;
        }
        public void Add(Score score)
        {
            throw new NotImplementedException();
        }

        public void Delete(Score score)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Score> GetAll()
        {
            var scores = _scores.AsQueryable();
            return scores.OrderBy(i => i.Id).ToList();
        }

        public Score GetById(int id)
        {
            return _scores.SingleOrDefault(i => i.Id == id);
        }

        public IEnumerable<Score> GetByVoter(string name)
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }

        public void Update(Score score)
        {
            throw new NotImplementedException();
        }
    }
}
