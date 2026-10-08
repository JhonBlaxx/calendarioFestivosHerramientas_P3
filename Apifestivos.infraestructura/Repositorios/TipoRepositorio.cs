using Microsoft.EntityFrameworkCore;
using apiFestivos.core.Interfaces.Repositorios;
using apiFestivos.dominio.Entidades;
using Apifestivos.infraestructura.Datos;

namespace Apifestivos.infraestructura.Repositorios
{
    public class TipoRepositorio : ITipoRepositorio
    {
        private readonly FestivosDbContext contexto;

        public TipoRepositorio(FestivosDbContext contexto)
        {
            this.contexto = contexto;
        }

        public async Task<List<Tipo>> ObtenerTodos()
        {
            return await contexto.Tipos.ToListAsync();
        }

        public async Task<Tipo?> ObtenerPorId(int id)
        {
            return await contexto.Tipos.FindAsync(id);
        }

        public async Task<Tipo> Crear(Tipo entidad)
        {
            contexto.Tipos.Add(entidad);
            await contexto.SaveChangesAsync();
            return entidad;
        }

        public async Task<bool> Actualizar(Tipo entidad)
        {
            contexto.Tipos.Update(entidad);
            var filas = await contexto.SaveChangesAsync();
            return filas > 0;
        }

        public async Task<bool> Eliminar(int id)
        {
            var entidad = await contexto.Tipos.FindAsync(id);
            if (entidad == null)
            {
                return false;
            }

            contexto.Tipos.Remove(entidad);
            await contexto.SaveChangesAsync();
            return true;
        }
    }
}
