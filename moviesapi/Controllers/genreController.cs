using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using movieapi.Context;
using movieapi.Model;

namespace movieapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class genreController : ControllerBase
    {
        private readonly MoviesDBContext _context;

        public genreController(MoviesDBContext context)
        {
            _context = context;
        }

        // GET: api/genre
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Genre>>> GetGenres()
        {
            return await _context.Genres.OrderBy(g => g.Name).ToListAsync();
        }

        // GET: api/genre/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<object>>> GetGenre(int id)
        {
            var movies = await _context.Movies.Where(m => m.GenreId == id).Select(m => new
            {
                m.Id,
                m.Title,
                m.Description,
                m.Rating
            }).ToListAsync();

            if (movies == null)
            {
                return NotFound();
            }
           
            return movies;
        }
    }
}
