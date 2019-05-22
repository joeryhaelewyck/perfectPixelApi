using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using perfectPixelApi.DTOs;
using perfectPixelApi.Exceptions;
using perfectPixelApi.Services;

namespace perfectPixelApi.Controllers
{
    [ApiConventionType(typeof(DefaultApiConventions))]
    [Produces("application/json")]
    [ApiController]
    public class ScoreController : ControllerBase
    {
        private readonly IScoreService _scoreService;

        public ScoreController(IScoreService scoreService)
        {
            _scoreService = scoreService;
        }

        // GET: api/Scores
        /// <summary>
        /// Get all the submitted scores
        /// </summary>
        /// <returns>array of scores </returns>

        [HttpGet]
        [Route("api/[controller]")]
        public IEnumerable<ScoreGetDTO> GetScores()
        {
            try
            {
                return _scoreService.GetAll();
            }
            catch
            {
                return null;
            }
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
            try
            {
                return _scoreService.GetById(id);
            }
            catch (ScoreNotFoundException)
            {
                return NotFound();
            }
            catch
            {
                return BadRequest();
            }

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
            try
            {
                return _scoreService.GetByImageId(imageId);
            }
            catch
            {
                return null;
            }
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
            try
            {
                return _scoreService.GetByVoter(email);
            }
            catch
            {
                return null;
            }
        }
        /// <summary>
        /// Adds an score to the database
        /// </summary>
        [HttpPost]
        [Route("api/[controller]/")]
        public ActionResult<ScoreGetDTO> PostScore(ScorePutDTO scoreDTO)
        {
            try
            {
                return _scoreService.Add(scoreDTO);
            }
            catch
            {
                return BadRequest();
            }
        }
        ///// <summary>
        ///// changes the value of a score
        ///// </summary>
        [HttpPatch]
        [Route("api/[controller]/{id}")]
        public ActionResult<ScoreGetDTO> PatchScore(int id, ScorePatchDTO scorePatch)
        {
            try
            {
                return _scoreService.ApplyPatch(id, scorePatch);
            }
            catch (ScoreNotFoundException)
            {
                return NotFound();
            }
            catch 
            {
                return BadRequest();
            }
        }
    }
}
