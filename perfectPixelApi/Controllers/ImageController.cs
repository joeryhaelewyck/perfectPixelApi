
using System.Linq;
using perfectPixelApi.Data;
using perfectPixelApi.Model;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

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
        [HttpGet]
        [Route("api/[controller]")]
        public IEnumerable<SubmittedImage> GetImages()
        {
            return _imageRepository.GetAll();
        }
        [HttpGet("{id}")]
        [Route("api/[controller]/{id}")]
        public ActionResult<SubmittedImage> GetImage(int id)
        {
            var image =  _imageRepository.GetById(id);
            if (image == null)
            {
                return NotFound();
            }
            return image;
        }
        [HttpGet]
        [Route("api/[controller]/month/{month}")]
        public IEnumerable<SubmittedImage> GetImagesByMonth(int month)
        {
            return _imageRepository.GetImagesByMonth(month);
            
        }
        [HttpGet]
        [Route("api/[controller]/name/{name}")]
        public IEnumerable<SubmittedImage> GetImagesByName(string name)
        {
            return _imageRepository.GetByName(name);

        }
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
