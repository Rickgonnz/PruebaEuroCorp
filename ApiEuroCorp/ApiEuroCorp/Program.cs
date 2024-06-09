using ApiEuroCorp.Data;
using ApiEuroCorp.Interfaces;
using ApiEuroCorp.Repositorios;
using ApiEuroCorp.Servicios;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Api", Version = "v1" });
});

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlite(builder.Configuration.GetConnectionString("Connection"));
});

builder.Services.AddScoped<IAutorRepositorio, AutorRepositorio>();
builder.Services.AddScoped<ILibroRepositorio, LibroRepositorio>();

builder.Services.AddScoped<IAutorService, AutorService>();
builder.Services.AddScoped<ILibroService, LibroService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
