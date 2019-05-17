
using System.Linq;
using perfectPixelApi.Data;
using perfectPixelApi.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace perfectPixelApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly ImageContext _context;
   
        public TodoController(ImageContext context)
        {
            _context = context;

            if (_context.MonthImages.Count() == 0)
            {
                _context.MonthImages.Add(new MonthImage { ImageName = "Image1" });
                _context.SaveChanges();
            }
        }
    }
}
