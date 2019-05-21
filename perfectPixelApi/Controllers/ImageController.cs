using perfectPixelApi.Model;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using NSwag.Annotations;
using perfectPixelApi.DTO;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace perfectPixelApi.Controllers
{
    [ApiConventionType(typeof(DefaultApiConventions))]
    [Produces("application/json")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        private readonly ISubmittedImageRepository _imageRepository;

        public ImageController(ISubmittedImageRepository context)
        {
            _imageRepository = context;

        }
        // GET: api/image
        /// <summary>
        /// Get all recipes ordered by name
        /// </summary>
        /// <returns>array of images</returns>
        [HttpGet]
        [Route("api/[controller]")]
        public IEnumerable<SubmittedImage> GetImages()
        {
            return _imageRepository.GetAll();
        }
        // GET: api/image/5
        /// <summary>
        /// Get the image with given id
        /// </summary>
        /// <param name="id">the id of the image</param>
        /// <returns>The image</returns>
        [HttpGet]
        [Route("api/[controller]/{id}")]
        public ActionResult<SubmittedImage> GetImageById(int id)
        {
            SubmittedImage image = _imageRepository.GetById(id);
            if (image == null)
            {
                return NotFound();
            }
            return image;
        }
        // GET: api/image/month/5
        /// <summary>
        /// Get the image with given id
        /// </summary>
        /// <param name="id">the number of the month</param>
        /// <returns>The image</returns>
        [HttpGet]
        [Route("api/[controller]/month/{month}")]
        public IEnumerable<SubmittedImage> GetImagesByMonth(byte month)
        {
            return _imageRepository.GetImagesByMonth(month);

        }
        // GET: api/image/name/jokkebrok
        /// <summary>
        /// Get the image with given name
        /// </summary>
        /// <param name="name">the name of the image</param>
        /// <returns>array of images </returns>
        [HttpGet]
        [Route("api/[controller]/name/{name}")]
        public IEnumerable<SubmittedImage> GetImagesByName(string name)
        {
            return _imageRepository.GetByName(name);

        }
        // GET: api/image/highscore/5
        /// <summary>
        /// Get the image with given id
        /// </summary>
        /// <param name="month">the number of the month</param>
        /// <returns>The image with the highest score for the given month</returns>
        [HttpGet]
        [Route("api/[controller]/highscore/{month}")]
        public ActionResult<SubmittedImage> GetImageWithHighestScoreForCertainMonth(byte month)
        {
            return _imageRepository.GetImageByHighScoreByMonth(month);

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
        public ActionResult<SubmittedImage> GetImagesByVoterbyMonth(string voter, byte month)
        {
            SubmittedImage image = _imageRepository.GetImageByVoterByMonth(voter,month);
            if (image == null)
            {
                return NotFound();
            }
            return image;

        }
        /// <summary>
        /// Adds an image to the database
        /// </summary>
        [HttpPost]
        [Route("api/[controller]/")]
        public ActionResult<SubmittedImage> PostImage(SubmittedImageDTO submittedImageDTO)
        {
            var imageToCreate = new SubmittedImage(submittedImageDTO.Name, submittedImageDTO.Month, submittedImageDTO.Image, submittedImageDTO.Voter);
            imageToCreate.Id = _imageRepository.GetNewID();
            _imageRepository.Add(imageToCreate);
            _imageRepository.SaveChanges();
            return CreatedAtAction(nameof(GetImageById), new { id = imageToCreate.Id }, imageToCreate);
        }
        /// <summary>
        /// deletes an image from the database
        /// </summary>
        [HttpDelete]
        [Route("api/[controller]/{id}")]
        public ActionResult<SubmittedImage> DeleteImage(int id)
        {
            SubmittedImage image = _imageRepository.GetById(id);
            if (image == null)
            {
                return NotFound();
            }
            _imageRepository.Delete(image);
            _imageRepository.SaveChanges();
            return image;
        }
        /// <summary>
        /// updates an image 
        /// </summary>
        [HttpPut]
        [Route("api/[controller]/{id}")]
        public ActionResult<SubmittedImage> ChangeImage(int id, SubmittedImageDTO imageDTO)
        {
            if(imageDTO == null)
            {
                return BadRequest("please insert information");
            }
            if(_imageRepository.GetById(id) == null)
            {
                return NotFound();
            }
            SubmittedImage imageToUpdate = new SubmittedImage(imageDTO.Name, imageDTO.Month,imageDTO.Image, imageDTO.Voter);
            imageToUpdate.Id = id;
            _imageRepository.Update(imageToUpdate);
            _imageRepository.SaveChanges();
            return imageToUpdate;
        }
        /// <summary>
        /// updates specific properties from an image 
        /// </summary>
        [HttpPatch]
        [Route("api/[controller]/{id}")]
        public ActionResult<SubmittedImage> ChangeImageSpecificProperties(int id, ImagePatchDTO imagePatch) {
            if(imagePatch == null)
            {
                return BadRequest("please insert information");
            }
            if (_imageRepository.GetById(id) == null)
            {
                return NotFound();
            }
            SubmittedImage currentImage = _imageRepository.GetById(id);
            return _imageRepository.ApplyPatch(currentImage, imagePatch);
        }

    }
}
