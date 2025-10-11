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
    public int AddOneMovie(Movie mov)
    {
        mov.WhenCreated = "1000";
        _movies.Add(mov);
        return _movies.IndexOf(mov);
    }
    public bool UpdateOneMovie(int id, Movie updatedMovie)
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
    public bool DeleteOneMovie(int id)
    {
        var movie = _movies.ElementAtOrDefault(id);
        if (movie == null)
        {
            return false;
        }
        _movies.RemoveAt(id);
        return true;
    }
}