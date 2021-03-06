using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using ScrumBoardWeb.Modules.App;
using ScrumBoardWeb.Modules.Infrasctucture;
using ScrumBoardWeb.Modules.Infrasctucture.Config;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "ScrumBoard API",
        Description = "An ASP.NET Core Web API for managing Scrum boards, columns and tasks.",
        License = new OpenApiLicense
        {
            Name = "License",
            Url = new Uri("http://www.wtfpl.net/")
        }
    });
});

builder.Services.AddDbContext<ScrumBoardDbContext>(
    options => options.UseMySql(
        builder.Configuration.GetConnectionString("Default"),
        ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("Default"))
));

builder.Services.AddScoped<IBoardService, BoardService>();
builder.Services.AddScoped<IBoardStorage, BoardStorage>();
builder.Services.AddScoped<IDTOService, DTOService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

app.Run();
