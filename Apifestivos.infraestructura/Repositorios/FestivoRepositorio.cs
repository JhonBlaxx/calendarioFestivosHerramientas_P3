using Microsoft.EntityFrameworkCore;
using apiFestivos.core.Interfaces.Repositorios;
using apiFestivos.dominio.Entidades;
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

        public async Task<Festivo> Crear(Festivo entidad)
        {
            contexto.Festivos.Add(entidad);
            await contexto.SaveChangesAsync();
            return entidad;
        }

        public async Task<bool> Actualizar(Festivo entidad)
        {
            contexto.Festivos.Update(entidad);
            var filas = await contexto.SaveChangesAsync();
            return filas > 0;
        }

        public async Task<bool> Eliminar(int id)
        {
            var entidad = await contexto.Festivos.FindAsync(id);
            if (entidad == null)
            {
                return false;
            }

            contexto.Festivos.Remove(entidad);
            await contexto.SaveChangesAsync();
            return true;
        }
    }
}
