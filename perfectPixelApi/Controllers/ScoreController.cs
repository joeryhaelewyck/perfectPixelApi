using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using perfectPixelApi.DTOs;
using perfectPixelApi.Repositories;
using perfectPixelApi.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace perfectPixelApi.Controllers
{
    [ApiConventionType(typeof(DefaultApiConventions))]
    [Produces("application/json")]
    public class ScoreController : ControllerBase
    {
        private readonly IScoreService _scoreService;

            public ScoreController(IScoreService scoreService)
        {
            _scoreService = scoreService;
        }
        
       
        [HttpGet]
        [Route("api/[controller]")]
        // GET: api/score/
        /// <summary>
        /// Get all the submitted scores
        /// </summary>
        /// <returns>array of scores </returns>
        public IEnumerable<ScoreGetDTO> GetScores()
        {
            return _scoreService.GetAll();
        }
        // GET: api/score/1
        /// <summary>
        /// Get the score with given id
        /// </summary>
        /// <param name="id">the id of the score</param>
        /// <returns>one specific score </returns>
        [HttpGet]
        [Route("api/[controller]/{id}")]
        public ActionResult<ScoreGetDTO> GetScoreById(int id)
        {
            return _scoreService.GetById(id);
        }
        // GET: api/score/imageid/2
        /// <summary>
        /// Get the scores with for the given imageId
        /// </summary>
        /// <param name="id">the id of the image</param>
        /// <returns>array of scores </returns>
        [HttpGet]
        [Route("api/[controller]/imageid/{imageId}")]
        public IEnumerable<ScoreGetDTO> GetScoreForSpecificImage(int imageId)
        {
            return _scoreService.GetByImageId(imageId);
        }
        // GET: api/score/voter/joeryhaelewyck@hotmail.com
        /// <summary>
        /// Get the scores with for the given voter(email)
        /// </summary>
        /// <param name="id">email of the voter</param>
        /// <returns>array of scores </returns>
        [HttpGet]
        [Route("api/[controller]/voter/{email}")]
        public IEnumerable<ScoreGetDTO> GetScoresForGivenVoter(string email)
        {
            return _scoreService.GetByVoter(email);
        }
        /// <summary>
        /// Adds an score to the database
        /// </summary>
        [HttpPost]
        [Route("api/[controller]/")]
        public ActionResult<Score> PostScore(ScorePutDTO scoreDTO)
        {
           return _scoreService.Add(scoreDTO);
        }
        ///// <summary>
        ///// changes the value of a score
        ///// </summary>
        [HttpPatch]
        [Route("api/[controller]/{id}")]
        public ActionResult<Score> PatchScore(int id, ScorePatchDTO scorePatch)
        {
            if (scorePatch == null)
            {
                return BadRequest("please insert information");
            }
            if (_scoreService.GetById(id) == null)
            {
                return NotFound();
            }
            return _scoreService.ApplyPatch(id, scorePatch);
        }

    }
}
