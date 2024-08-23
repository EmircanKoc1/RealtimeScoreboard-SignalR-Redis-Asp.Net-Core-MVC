using RealtimeScoreBoard.WebApp.Contexts;
using RealtimeScoreBoard.WebApp.Hubs;
using RealtimeScoreBoard.WebApp.Repositories;
using RealtimeScoreBoard.WebApp.Services;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllersWithViews();

builder.Services.AddSingleton<RedisContext>(p => new RedisContext(builder.Configuration.GetConnectionString("Redis")!));
builder.Services.AddSingleton<IRedisScoreboardRepository, RedisScoreboardRepository>();
builder.Services.AddSingleton<IScoreboardService, ScoreboardService>();

builder.Services.AddSignalR();

var app = builder.Build();


if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapHub<ScoreboardHub>("/scoreboardhub");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
