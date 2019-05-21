using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;
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
        // GET: api/score/
        /// <summary>
        /// Get all the submitted scores
        /// </summary>
        /// <returns>array of scores </returns>
        [HttpGet]
        [Route("api/[controller]")]
        public IEnumerable<Score> GetScores()
        {
            return _scoreRepository.GetAll();
        }
        // GET: api/score/1
        /// <summary>
        /// Get the score with given id
        /// </summary>
        /// <param name="id">the id of the score</param>
        /// <returns>one specific score </returns>
        [HttpGet]
        [Route("api/[controller]/{id}")]
        public ActionResult<Score> GetScoreById(int id)
        {
            var Score = _scoreRepository.GetById(id);
            if (Score == null)
            {
                return NotFound();
            }
            return Score;
        }
        // GET: api/score/imageid/2
        /// <summary>
        /// Get the scores with for the given imageId
        /// </summary>
        /// <param name="id">the id of the image</param>
        /// <returns>array of scores </returns>
        [HttpGet]
        [Route("api/[controller]/imageid/{imageId}")]
        public IEnumerable<Score> GetScoreForSpecificImage(int imageId)
        {
            return _scoreRepository.GetByImageId(imageId);
        }
        // GET: api/score/voter/joeryhaelewyck@hotmail.com
        /// <summary>
        /// Get the scores with for the given voter(email)
        /// </summary>
        /// <param name="id">email of the voter</param>
        /// <returns>array of scores </returns>
        [HttpGet]
        [Route("api/[controller]/voter/{email}")]
        public IEnumerable<Score> GetScoresForGivenVoter(string email)
        {
            return _scoreRepository.GetByVoter(email);
        }

    }
}
