using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using perfectPixelApi.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace perfectPixelApi.Controllers
{
    [ApiConventionType(typeof(DefaultApiConventions))]
    [Produces("application/json")]
    public class ScoreController : ControllerBase
    {
        private readonly IScoreRepository _scoreRepository;
        public ScoreController(IScoreRepository context)
        {
            _scoreRepository = context;
        }

        [HttpGet]
        [Route("api/[controller]")]
        public IEnumerable<Score> GetScores()
        {
            return _scoreRepository.GetAll();
        }
        [HttpGet("{id}")]
        [Route("api/[controller]/{id}")]
        public ActionResult<Score> GetImage(int id)
        {
            var Score = _scoreRepository.GetById(id);
            if (Score == null)
            {
                return NotFound();
            }
            return Score;
        }

        
    }
}
