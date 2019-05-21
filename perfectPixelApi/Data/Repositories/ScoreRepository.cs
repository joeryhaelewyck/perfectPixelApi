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
            return scores.ToList();
        }

        public Score GetById(int id)
        {
            return _scores.SingleOrDefault(s => s.Id == id);
        }

        public IEnumerable<Score> GetByImageId(int imageId)
        {
            return _scores.Where(s => s.Idsubmittedimage == imageId);
        }

        public IEnumerable<Score> GetByVoter(string email)
        {
            return _scores.Where(s => s.Voter == email);
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
