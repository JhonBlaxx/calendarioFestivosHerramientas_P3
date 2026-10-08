using apiFestivos.core.Interfaces.Repositorios;
using apiFestivos.core.Interfaces.Servicios;
using apiFestivos.dominio.Entidades;

namespace apiFestivos.aplicacion.Servicios
{
    public class PaisServicio : IPaisServicio
    {
        private readonly IPaisRepositorio repositorio;

        public PaisServicio(IPaisRepositorio repositorio)
        {
            this.repositorio = repositorio;
        }

        public async Task<List<Pais>> ObtenerTodos()
        {
            return await repositorio.ObtenerTodos();
        }

        public async Task<Pais?> ObtenerPorId(int id)
        {
            return await repositorio.ObtenerPorId(id);
        }

        public async Task<Pais> Crear(Pais entidad)
        {
            return await repositorio.Crear(entidad);
        }

        public async Task<bool> Actualizar(Pais entidad)
        {
            return await repositorio.Actualizar(entidad);
        }

        public async Task<bool> Eliminar(int id)
        {
            return await repositorio.Eliminar(id);
        }
    }
}
