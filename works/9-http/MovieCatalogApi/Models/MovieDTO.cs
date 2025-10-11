namespace MovieCatalogApi.Models
{
    public class MovieDTO
    {
        public string Title { get; set; }
        public string Director { get; set; }

        public MovieDTO(string title, string director)
        {
            Title = title;
            Director = director;
        }
    }
}