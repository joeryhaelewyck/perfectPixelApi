using Microsoft.EntityFrameworkCore;
using perfectPixelApi.Models;
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
            _scores.Add(score);
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
            return _scores.Where(s => s.IdSubmittedImage == imageId);
        }

        public Score GetByImageIdAndVoter(int imageId, string voter)
        {
            var scoresForSpecificImage = GetByImageId(imageId);
            return scoresForSpecificImage.FirstOrDefault(s => s.Voter == voter);
        }

        public IEnumerable<Score> GetByVoter(string email)
        {
            return _scores.Where(s => s.Voter == email);
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }

        public void Update(Score score)
        {
            _scores.Update(score);
        }
    }
}
