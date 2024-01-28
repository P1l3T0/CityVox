using CityVoxWeb.API;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpContextAccessor();

var app = builder
            .ConfigureServices()
            .ConfigurePipeline();

app.Run();
