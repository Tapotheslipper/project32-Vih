using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Mvc;
using MovieCatalogApi.Models;

namespace MovieCatalogApi.Controllers
{
    [ApiController]
    [Route("api/movies")]
    public class MoviesController : ControllerBase
    {
        private static List<Movie> movies = new List<Movie> {};

        [HttpGet]
        public IActionResult GetAll()
        {
            var moviesDTO = movies.Select((mov) => new MovieDTO(mov.Title, mov.Director));
            return Ok(moviesDTO);
        }
        
        [HttpGet("{id}")]
        public IActionResult GetOne(int id)
        {
            var movie = movies.ElementAtOrDefault(id);
            if (movie == null)
            {
                return NotFound();
            }
            var movieDTO = new MovieDTO(movie.Title, movie.Director);
            return Ok(movieDTO);
        }
        
        [HttpPost]
        public IActionResult AddOneMovie([FromBody] MovieDTO movieDTO)
        {
            var movie = new Movie(movieDTO.Title, movieDTO.Director, "1000");
            movies.Add(movie);
            var newMovieId = movies.Count - 1;
            return CreatedAtAction(nameof(GetOne), new { id = newMovieId }, movieDTO);
        }
        
        [HttpPut("{id}")]
        public IActionResult UpdateOneMovie(int id, [FromBody] MovieDTO updatedMovieDTO)
        {
            var mov = movies.ElementAtOrDefault(id);
            if (mov == null)
            {
                return NotFound();
            }
            mov.Title = updatedMovieDTO.Title;
            mov.Director = updatedMovieDTO.Director;
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteOneMovie(int id)
        {
            var mov = movies.ElementAtOrDefault(id);
            if (mov == null)
            {
                return NotFound();
            }
            movies.RemoveAt(id);
            return NoContent();
        }
    }
}

