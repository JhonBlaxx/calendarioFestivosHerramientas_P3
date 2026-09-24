using Microsoft.EntityFrameworkCore;
using apiFestivos.dominio.Entidades;
using apiFestivos.dominio.Interfaces;
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

        public async Task<Tipo> Crear(Tipo tipo)
        {
            contexto.Tipos.Add(tipo);
            await contexto.SaveChangesAsync();
            return tipo;
        }

        public async Task<bool> Actualizar(Tipo tipo)
        {
            contexto.Tipos.Update(tipo);
            var filas = await contexto.SaveChangesAsync();
            return filas > 0;
        }

        public async Task<bool> Eliminar(int id)
        {
            var tipo = await contexto.Tipos.FindAsync(id);
            if (tipo == null)
            {
                return false;
            }

            contexto.Tipos.Remove(tipo);
            await contexto.SaveChangesAsync();
            return true;
        }
    }
}
