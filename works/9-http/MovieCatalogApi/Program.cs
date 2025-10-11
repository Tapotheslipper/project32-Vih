var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<MovieService>();
builder.Services.AddControllers();

// builder.Services.AddEndpointsApiExplorer();
// builder.Services.AddSwaggerGen();

var app = builder.Build();
app.MapControllers();

app.Run();
