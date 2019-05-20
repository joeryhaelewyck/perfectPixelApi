using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace perfectPixelApi.Model
{
    public interface IScoreRepository
    {
        Score GetById(int id);
        IEnumerable<Score> GetByVoter(string name);
        IEnumerable<Score> GetAll();
        void Add(Score score);
        void Delete(Score score);
        void Update(Score score);
        void SaveChanges();
    }
}

