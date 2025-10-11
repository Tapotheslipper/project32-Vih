using Microsoft.AspNetCore.Components.Web;

namespace MovieCatalogApi.Models
{
    public class Movie
    {
        public string Title { get; set; }
        public string Director { get; set; }
        public string WhenCreated { get; set; }

        public Movie(string title, string director, string whenCreated)
        {
            Title = title;
            Director = director;
            WhenCreated = whenCreated;
        }
    }
}

