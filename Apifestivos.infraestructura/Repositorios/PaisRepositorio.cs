using Microsoft.EntityFrameworkCore;
using apiFestivos.core.Interfaces.Repositorios;
using apiFestivos.dominio.Entidades;
using Apifestivos.infraestructura.Datos;

namespace Apifestivos.infraestructura.Repositorios
{
    public class PaisRepositorio : IPaisRepositorio
    {
        private readonly FestivosDbContext contexto;

        public PaisRepositorio(FestivosDbContext contexto)
        {
            this.contexto = contexto;
        }

        public async Task<List<Pais>> ObtenerTodos()
        {
            return await contexto.Paises.ToListAsync();
        }

        public async Task<Pais?> ObtenerPorId(int id)
        {
            return await contexto.Paises.FindAsync(id);
        }

        public async Task<Pais> Crear(Pais entidad)
        {
            contexto.Paises.Add(entidad);
            await contexto.SaveChangesAsync();
            return entidad;
        }

        public async Task<bool> Actualizar(Pais entidad)
        {
            contexto.Paises.Update(entidad);
            var filas = await contexto.SaveChangesAsync();
            return filas > 0;
        }

        public async Task<bool> Eliminar(int id)
        {
            var entidad = await contexto.Paises.FindAsync(id);
            if (entidad == null)
            {
                return false;
            }

            contexto.Paises.Remove(entidad);
            await contexto.SaveChangesAsync();
            return true;
        }
    }
}
