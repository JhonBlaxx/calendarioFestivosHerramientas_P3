using Microsoft.EntityFrameworkCore;
using apiFestivos.dominio.Interfaces;
using Apifestivos.infraestructura.Datos;
using Apifestivos.infraestructura.Repositorios;
using Taller_1_Herramientas.Servicios;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<FestivosDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("FestivosConnection")));

builder.Services.AddScoped<IPaisRepositorio, PaisRepositorio>();
builder.Services.AddScoped<ITipoRepositorio, TipoRepositorio>();
builder.Services.AddScoped<IFestivoRepositorio, FestivoRepositorio>();
builder.Services.AddScoped<ICalendarioServicio, CalendarioServicio>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
