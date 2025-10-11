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
        return Ok(movies);
    }
    [HttpGet("{id}")]
    public IActionResult GetOne(int id)
    {
        var movie = _movieService.GetOneMovie(id);
        if (movie == null)
        {
            return NotFound();
        }
        return Ok(movie);
    }
    [HttpPost]
    public bool AddOneMovie([FromBody] Movie movie)
    {
        _movieService.AddMovie(movie);
        return true;
    }
    [HttpPut("{id}")]
    public IActionResult UpdateOneMovie(int id, [FromBody] Movie updatedMovie)
    {
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