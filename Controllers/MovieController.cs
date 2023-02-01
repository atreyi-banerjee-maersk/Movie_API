using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieTicketApi.Data;
using MovieTicketApi.Models;

namespace MovieTicketApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly MovieDbContext _context;
        public MovieController(MovieDbContext context) => _context = context;
        [HttpGet]
        public async Task<IEnumerable<Movie>> Get()
            => await _context.Movies.ToListAsync();
        [HttpGet("id")]
        public async Task<IActionResult> GetById(int id)
        {
            var movie = await _context.Movies.FindAsync(id);
            return movie == null ? NotFound() : Ok(movie);
        }

        [HttpPost]

        public async Task<IActionResult> Create(Movie movie)
        {
            await _context.Movies.AddAsync(movie);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = movie.id }, movie);
        }
        [HttpPut("id")]
        public async Task<IActionResult> Update(int id, Movie movie)
        {
            if (id != movie.id) return BadRequest();
            _context.Entry(movie).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();

        }
        [HttpDelete("id")]
        public async Task<IActionResult> Delete(int id)
        {
            var movieToDelete = await _context.Movies.FindAsync(id);
            if (movieToDelete == null) return NotFound();
            _context.Movies.Remove(movieToDelete);
            await _context.SaveChangesAsync();
            return NoContent();
        }


    }
}
