using Microsoft.EntityFrameworkCore;
using perfectPixelApi.DTO;
using perfectPixelApi.Model;
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

        public Score ApplyPatch(Score currentScore, ScorePatchDTO scorePatch)
        {
            currentScore.ImageScore = scorePatch.ImageScore;
            _scores.Update(currentScore);
            SaveChanges();
            return currentScore;
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

        public int GetNewID()
        {
            int id = _scores.OrderByDescending(s => s.Id).Select(s => s.Id).First();
            return id + 1;
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }
    }
}
