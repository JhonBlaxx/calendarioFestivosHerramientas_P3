using Microsoft.EntityFrameworkCore;
using apiFestivos.dominio.Entidades;
using apiFestivos.dominio.Interfaces;
using Apifestivos.infraestructura.Datos;

namespace Apifestivos.infraestructura.Repositorios
{
    public class FestivoRepositorio : IFestivoRepositorio
    {
        private readonly FestivosDbContext contexto;

        public FestivoRepositorio(FestivosDbContext contexto)
        {
            this.contexto = contexto;
        }

        public async Task<List<Festivo>> ObtenerTodos()
        {
            return await contexto.Festivos.ToListAsync();
        }

        public async Task<Festivo?> ObtenerPorId(int id)
        {
            return await contexto.Festivos.FindAsync(id);
        }

        public async Task<List<Festivo>> ObtenerPorPais(int idPais)
        {
            return await contexto.Festivos.Where(f => f.IdPais == idPais).ToListAsync();
        }

        public async Task<Festivo> Crear(Festivo festivo)
        {
            contexto.Festivos.Add(festivo);
            await contexto.SaveChangesAsync();
            return festivo;
        }

        public async Task<bool> Actualizar(Festivo festivo)
        {
            contexto.Festivos.Update(festivo);
            var filas = await contexto.SaveChangesAsync();
            return filas > 0;
        }

        public async Task<bool> Eliminar(int id)
        {
            var festivo = await contexto.Festivos.FindAsync(id);
            if (festivo == null)
            {
                return false;
            }

            contexto.Festivos.Remove(festivo);
            await contexto.SaveChangesAsync();
            return true;
        }
    }
}
