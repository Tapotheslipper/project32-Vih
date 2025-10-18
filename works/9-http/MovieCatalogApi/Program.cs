var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<MovieService>();
builder.Services.AddControllers();

var app = builder.Build();
<<<<<<< Updated upstream
=======

<<<<<<< Updated upstream
>>>>>>> Stashed changes
=======
>>>>>>> Stashed changes
app.MapControllers();

app.Run();
