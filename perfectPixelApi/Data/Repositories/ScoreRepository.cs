﻿using Microsoft.EntityFrameworkCore;
using perfectPixelApi.DTOs;
using perfectPixelApi.Repositories;
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
            Score updateScore = new Score.Builder()
                .withImageScore(scorePatch.ImageScore)
                .withSubmittedImageId(currentScore.IdSubmittedImage)
                .withVoter(currentScore.Voter)
                .Build();
            _scores.Update(updateScore);
            SaveChanges();
            return updateScore;
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
    }
}
