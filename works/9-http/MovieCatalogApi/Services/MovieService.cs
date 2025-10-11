using MovieCatalogApi.Models;

public class MovieService
{
    // fields
    private readonly List<Movie> _movies = new List<Movie>();

    // constructor
    public MovieService() { }

    // methods
    public IEnumerable<Movie> GetAllMovies()
    {
        return _movies;
    }
    public Movie GetOneMovie(int id)
    {
        return _movies.ElementAtOrDefault(id);
    }
    public void AddMovie(Movie mov)
    {
        mov.WhenCreated = "1000";
        _movies.Add(mov);
    }
    public bool UpdateMovie(int id, Movie updatedMovie)
    {
        var mov = _movies.ElementAtOrDefault(id);
        if (mov == null)
        {
            return false;
        }
        mov.Title = updatedMovie.Title;
        mov.Director = updatedMovie.Director;
        _movies[id] = mov;
        return true;
    }
    public bool DeleteMovie(int id)
    {
        var movie = _movies.ElementAtOrDefault(id);
        if (movie == null)
        {
            return false;
        }
        _movies.Remove(_movies[id]);
        return true;
    }
}