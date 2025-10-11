using Microsoft.AspNetCore.Components.Web;

namespace MovieCatalogApi.Models;

public class Movie
{
    public string Title { get; set; }
    public string Director { get; set; }

    public Movie(string title, string director)
    {
        Title = title;
        Director = director;
    }
}