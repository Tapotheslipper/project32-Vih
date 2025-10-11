using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Mvc;
using MovieCatalogApi.Models;

namespace MovieCatalogApi.Controllers
{
    [ApiController]
    [Route("api/movies")]
    public class MoviesController : ControllerBase
    {
        private readonly MovieService _movieService;

        public MoviesController(MovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var movies = _movieService.GetAllMovies();
            var moviesDTO = movies.Select((mov) => new MovieDTO(mov.Title, mov.Director));
            return Ok(moviesDTO);
        }
        
        [HttpGet("{id}")]
        public IActionResult GetOne(int id)
        {
            var movie = _movieService.GetOneMovie(id);
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
            _movieService.AddMovie(movie);
            return CreatedAtAction(nameof(GetOne), new { id = _movieService.GetAllMovies().Count() - 1 }, movieDTO);
        }
        
        [HttpPut("{id}")]
        public IActionResult UpdateOneMovie(int id, [FromBody] MovieDTO updatedMovieDTO)
        {
            var updatedMovie = new Movie(updatedMovieDTO.Title, updatedMovieDTO.Director, "1000");
            var mov = _movieService.UpdateMovie(id, updatedMovie);
            if (!mov)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteOneMovie(int id)
        {
            var mov = _movieService.DeleteMovie(id);
            if (!mov)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}

