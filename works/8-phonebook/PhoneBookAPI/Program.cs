var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<ContactService>();
builder.Services.AddControllers();

var app = builder.Build();
app.MapControllers();

app.Run();