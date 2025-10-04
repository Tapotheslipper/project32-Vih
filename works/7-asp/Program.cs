var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();
app.UseEndpoints(endpoint => {
    endpoint.MapControllerRoute(
        name: "default",
        pattern: "{controller=Homey}/{action=Index}"
    );
});

app.Run();
