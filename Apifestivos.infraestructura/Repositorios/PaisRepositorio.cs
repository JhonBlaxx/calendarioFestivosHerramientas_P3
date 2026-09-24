using Microsoft.EntityFrameworkCore;
using apiFestivos.dominio.Entidades;
using apiFestivos.dominio.Interfaces;
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

        public async Task<Pais> Crear(Pais pais)
        {
            contexto.Paises.Add(pais);
            await contexto.SaveChangesAsync();
            return pais;
        }

        public async Task<bool> Actualizar(Pais pais)
        {
            contexto.Paises.Update(pais);
            var filas = await contexto.SaveChangesAsync();
            return filas > 0;
        }

        public async Task<bool> Eliminar(int id)
        {
            var pais = await contexto.Paises.FindAsync(id);
            if (pais == null)
            {
                return false;
            }

            contexto.Paises.Remove(pais);
            await contexto.SaveChangesAsync();
            return true;
        }
    }
}
