using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using movieapi.Context;
using movieapi.Model;

namespace movieapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class movieController : ControllerBase
    {
        private readonly MoviesDBContext _context;

        public movieController(MoviesDBContext context)
        {
            _context = context;
        }

        // GET: api/movie/5
        [HttpGet("{id}")]
        public async Task<ActionResult<object>> GetMovie(int id)
        {
            var movie = await _context.Movies.Where(m => m.Id == id).Select(m => new
            {
                m.Id,
                m.Title,
                m.Description,
                m.Director,
                m.Actors,
                m.Rating,
                m.Year,
                m.GenreId,
                Genre = _context.Genres.Where(g => g.Id == m.GenreId).Select(g => g.Name).First(),
                Poster = Convert.ToBase64String(m.Poster)
            }).FirstAsync();

            if (movie == null)
            {
                return NotFound();
            }

            return movie;
        }
    }
}
