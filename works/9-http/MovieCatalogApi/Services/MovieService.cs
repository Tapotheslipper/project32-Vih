using MovieCatalogApi.Models;

public class MovieService
{
    private readonly List<Movie> _movies = new List<Movie>();

    public MovieService()
    {
        _movies.Add(new Movie("title-example", "director-example"));
    }

    public IEnumerable<Movie> GetAllMovies() {
        return _movies;
    }
    public Movie GetOneMovie(int id) {
        return _movies[id];
    }
    public void AddMovie(Movie mov) {
        _movies.Add(mov);
    }
    public bool UpdateMovie(int id, Movie updatedMovie) {
        var mov = _movies[id];
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
        if (_movies.Count - 1 != id)
        {
            return false;
        }
        _movies.Remove(_movies[id]);
        return true;
    }
}