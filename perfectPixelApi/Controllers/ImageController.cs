
using System.Linq;
using perfectPixelApi.Data;
using perfectPixelApi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace perfectPixelApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        private readonly ImageContext _context;
   
        public ImageController(ImageContext context)
        {
            _context = context;
            // in case there is no data in the database
            if (_context.MonthImages.Count() == 0)
            {
                _context.MonthImages.Add(new Image { ImageName = "ImageOfAnEmptyDatabase" });
                _context.SaveChanges();
            }

        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Image>>> GetImagesOfTheMonth()
        {
            return await _context.MonthImages.ToListAsync();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Image>> GetFirstImageOfTheMonth(long id)
        {
            var image = await _context.MonthImages.FindAsync(id);

            if (image == null)
            {
                return NotFound();
            }

            return image;
        }
        [HttpPost]
        public async Task<ActionResult<Image>> PostImage(Image image)
        {
            _context.MonthImages.Add(image);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetFirstImageOfTheMonth), new { id = image.Id }, image);
        }
    }
}
