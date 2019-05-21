using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;
using perfectPixelApi.DTO;
using perfectPixelApi.Model;
using perfectPixelApi.services;

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
        
        // GET: api/score/
        /// <summary>
        /// Get all the submitted scores
        /// </summary>
        /// <returns>array of scores </returns>
        [HttpGet]
        [Route("api/[controller]")]
        public IEnumerable<ScoreDTO> GetScores()
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
        /// <summary>
        /// Adds an score to the database
        /// </summary>
        [HttpPost]
        [Route("api/[controller]/")]
        public ActionResult<Score> PostScore(ScoreDTO scoreDTO)
        {
            if (_scoreRepository.GetByImageIdAndVoter(scoreDTO.IdSubmittedImage, scoreDTO.Voter) != null)
            {
                return BadRequest("You already voted");
            }
            if (_submittedImageRepository.GetById(scoreDTO.IdSubmittedImage).Creator == scoreDTO.Voter)
            {
                return BadRequest("You can't vote on yourself!!!");
            }
            Score scoreToCreate = new Score(scoreDTO.IdSubmittedImage, scoreDTO.ImageScore, scoreDTO.Voter);
            //scoreToCreate.Id = _scoreRepository.GetNewID();
            _scoreRepository.Add(scoreToCreate);
            _scoreRepository.SaveChanges();
            return CreatedAtAction(nameof(GetScoreById), new { id = scoreToCreate.Id }, scoreToCreate);
        }
        /// <summary>
        /// changes the value of a score
        /// </summary>
        [HttpPatch]
        [Route("api/[controller]/{id}")]
        public ActionResult<Score> PatchScore(int id, ScorePatchDTO scorePatch)
        {
            if (scorePatch == null)
            {
                return BadRequest("please insert information");
            }
            if (_scoreRepository.GetById(id) == null)
            {
                return NotFound();
            }
            Score currentScore = _scoreRepository.GetById(id);
            return _scoreRepository.ApplyPatch(currentScore, scorePatch);
        }

    }
}
