using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Mvc;
using MovieCatalogApi.Models;

namespace MovieCatalogApi.Controllers;

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
    public IActionResult AddMovie([FromBody] MovieDTO movieDTO)
    {
        if (movieDTO == null)
        {
            return BadRequest("Данные введены некорректно.");
        }
        var movie = new Movie(movieDTO.Title, movieDTO.Director, "1000");
        var index = _movieService.AddOneMovie(movie);
        var uri = Url.Action("GetOne", new { id = index });
        return Created(uri, movieDTO);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateMovie(int id, [FromBody] MovieDTO updatedMovieDTO)
    {
        var updatedMovie = new Movie(updatedMovieDTO.Title, updatedMovieDTO.Director, "1000");
        var mov = _movieService.UpdateOneMovie(id, updatedMovie);
        if (!mov)
        {
            return NotFound();
        }
        return Ok(updatedMovieDTO);
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteMovie(int id)
    {
        var mov = _movieService.DeleteOneMovie(id);
        if (!mov)
        {
            return NotFound();
        }
        return NoContent();
    }
}

