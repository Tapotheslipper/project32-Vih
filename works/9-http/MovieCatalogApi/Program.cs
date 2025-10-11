using MovieCatalogApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

var app = builder.Build();

List<Movie> movies = new List<Movie> {};

app.MapControllers();

app.Run();
