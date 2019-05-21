using System.Collections.Generic;

namespace perfectPixelApi.Model
{
    public interface IScoreRepository
    {
        Score GetById(int id);
        IEnumerable<Score> GetByVoter(string name);
        IEnumerable<Score> GetAll();
        IEnumerable<Score> GetByImageId(int id);
        void Add(Score score);
        void Delete(Score score);
        void Update(Score score);
        void SaveChanges();
        int GetNewID();
    }
}

