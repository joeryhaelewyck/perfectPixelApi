
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
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        private readonly ISubmittedImageRepository _imageRepository;
   
        public ImageController(ISubmittedImageRepository context)
        {
            _imageRepository = context;
        
        }
        [HttpGet]
        public IEnumerable<SubmittedImage> GetImages()
        {
            var images = _imageRepository.GetAll();
            if(images == null)
            {
               List<SubmittedImage> fakeList = new List<SubmittedImage>();
            }
            return images;
        }
        [HttpGet("{id}")]
        public ActionResult<SubmittedImage> GetImage(long id)
        {
            var image =  _imageRepository.GetById(id);

            if (image == null)
            {
                return NotFound();
            }

            return image;
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
