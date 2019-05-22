using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using perfectPixelApi.DTOs;
using perfectPixelApi.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace perfectPixelApi.Controllers
{
    [ApiConventionType(typeof(DefaultApiConventions))]
    [Produces("application/json")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        private readonly ISubmittedImageService _imageService;

        public ImageController(ISubmittedImageService imageService)
        {
            _imageService = imageService;

        }
        // GET: api/image
        /// <summary>
        /// Get all recipes ordered by name
        /// </summary>
        /// <returns>array of images</returns>
        [HttpGet]
        [Route("api/[controller]")]
        public IEnumerable<ImageGetDTO> GetImages()
        {
            return _imageService.GetAll();
        }
        // GET: api/image/5
        /// <summary>
        /// Get the image with given id
        /// </summary>
        /// <param name="id">the id of the image</param>
        /// <returns>The image</returns>
        [HttpGet]
        [Route("api/[controller]/{id}")]
        public ActionResult<ImageGetDTO> GetImageById(int id)
        {
            return _imageService.GetImageById(id);
            
        }
        // GET: api/image/month/5
        /// <summary>
        /// Get the image with given id
        /// </summary>
        /// <param name="id">the number of the month</param>
        /// <returns>The image</returns>
        [HttpGet]
        [Route("api/[controller]/month/{month}")]
        public IEnumerable<ImageGetDTO> GetImagesByMonth(byte month)
        {
            return _imageService.GetImagesByMonth(month);

        }
        // GET: api/image/name/jokkebrok
        /// <summary>
        /// Get the image with given name
        /// </summary>
        /// <param name="name">the name of the image</param>
        /// <returns>array of images </returns>
        [HttpGet]
        [Route("api/[controller]/name/{name}")]
        public IEnumerable<ImageGetDTO> GetImagesByName(string name)
        {
            return _imageService.GetImagesByName(name);

        }
        // GET: api/image/highscore/5
        /// <summary>
        /// Get the image with given id
        /// </summary>
        /// <param name="month">the number of the month</param>
        /// <returns>The image with the highest score for the given month</returns>
        [HttpGet]
        [Route("api/[controller]/highscore/{month}")]
        public ActionResult<ImageGetDTO> GetImageWithHighestScoreForCertainMonth(byte month)
        {
            return _imageService.GetImageByHighScoreByMonth(month);

        }
        // GET: api/image/voter/joeryhaelewyck@hotmail.com/month/5
        /// <summary>
        /// Get the submitted image for a given voter and given month
        /// </summary>
        /// <param name="voter">mail of the voter</param>
        /// <param name="month">the number of the month</param>
        /// <returns>The image with the highest score for the given month</returns>
        [HttpGet]
        [Route("api/[controller]/voter/{voter}/month/{month}")]
        public ActionResult<ImageGetDTO> GetImagesByVoterbyMonth(string voter, byte month)
        {
            return _imageService.GetImageByVoterByMonth(voter, month);

        }
        /// <summary>
        /// Adds an image to the database
        /// </summary>
        [HttpPost]
        [Route("api/[controller]/")]
        public ActionResult<ImageGetDTO> PostImage(ImagePutDTO imageDTO)
        {
            return _imageService.Add(imageDTO);
        }
        /// <summary>
        /// deletes an image from the database
        /// </summary>
        [HttpDelete]
        [Route("api/[controller]/{id}")]
        public ActionResult<ImageGetDTO> DeleteImage(int id)
        {
            return _imageService.Delete(id);
        }
        /// <summary>
        /// updates an image 
        /// </summary>
        [HttpPut]
        [Route("api/[controller]/{id}")]
        public ActionResult<ImageGetDTO> ChangeImage(int id, ImagePutDTO imageDTO)
        {
            return _imageService.Update(id, imageDTO);
        }
        /// <summary>
        /// updates specific properties from an image 
        /// </summary>
        [HttpPatch]
        [Route("api/[controller]/{id}")]
        public ActionResult<ImageGetDTO> ChangeImageSpecificProperties(int id, ImagePatchDTO imagePatch)
        {
           
            return _imageService.ApplyPatch(id, imagePatch);
        }

    }
}
