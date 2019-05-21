﻿using perfectPixelApi.Model;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using NSwag.Annotations;

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
            var image =  _imageRepository.GetById(id);
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
        public IEnumerable<SubmittedImage> GetImagesByMonth(int month)
        {
            return _imageRepository.GetImagesByMonth(month);
            
        }
        // GET: api/image/name/jokkebrok
        /// <summary>
        /// Get the image with given id
        /// </summary>
        /// <param name="id">the name of the image</param>
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
        /// <param name="id">the number of the month</param>
        /// <returns>The image with the highest score for the given month</returns>
        [HttpGet]
        [Route("api/[controller]/highscore/{month}")]
        public ActionResult<SubmittedImage> GetImageWithHighestScoreForCertainMonth(int month)
        {
            return _imageRepository.GetImageByHighScoreByMonth(month);

        }
        //[HttpPost]
        //public async Task<ActionResult<SubmittedImage>> PostImage(SubmittedImage image)
        //{
        //    _imageRepository.MonthImages.Add(image);
        //    await _imageRepository.SaveChangesAsync();

        //    return CreatedAtAction(nameof(GetFirstImageOfTheMonth), new { id = image.Id }, image);
        //}
    }
}
