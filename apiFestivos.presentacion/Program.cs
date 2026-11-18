using Microsoft.EntityFrameworkCore;
using apiFestivos.aplicacion.Servicios;
using apiFestivos.core.Interfaces.Repositorios;
using apiFestivos.core.Interfaces.Servicios;
using Apifestivos.infraestructura.Datos;
using Apifestivos.infraestructura.Repositorios;

namespace apiFestivos.presentacion
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("Angular", politica =>
                {
                    politica.WithOrigins("http://localhost:4200")
                            .AllowAnyHeader()
                            .AllowAnyMethod();
                });
            });

            builder.Services.AddDbContext<FestivosDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("FestivosConnection")));

            builder.Services.AddScoped<IPaisRepositorio, PaisRepositorio>();
            builder.Services.AddScoped<ITipoRepositorio, TipoRepositorio>();
            builder.Services.AddScoped<IFestivoRepositorio, FestivoRepositorio>();

            builder.Services.AddScoped<IPaisServicio, PaisServicio>();
            builder.Services.AddScoped<ITipoServicio, TipoServicio>();
            builder.Services.AddScoped<IFestivoServicio, FestivoServicio>();
            builder.Services.AddScoped<ICalendarioServicio, CalendarioServicio>();

            var app = builder.Build();

            app.UseSwagger();
            app.UseSwaggerUI();

            app.UseHttpsRedirection();

            app.UseCors("Angular");

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
