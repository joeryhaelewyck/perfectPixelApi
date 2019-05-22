using System.Collections.Generic;
using perfectPixelApi.DTOs;

namespace perfectPixelApi.Models
{
    public interface IScoreRepository
    {
        Score GetById(int id);
        Score GetByImageIdAndVoter(int imageId, string voter);
        IEnumerable<Score> GetByVoter(string name);
        IEnumerable<Score> GetAll();
        IEnumerable<Score> GetByImageId(int id);
        void Add(Score score);
        void Update(Score score);
        void SaveChanges();
        
    }
}

