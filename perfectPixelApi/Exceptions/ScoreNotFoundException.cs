using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace perfectPixelApi.Exceptions
{
    public class ScoreNotFoundException : Exception
    {
        public ScoreNotFoundException()
        {
        }
        public ScoreNotFoundException(string message) : base(message)
        {
        }
        public ScoreNotFoundException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}
