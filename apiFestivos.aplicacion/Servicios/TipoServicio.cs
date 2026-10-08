using apiFestivos.core.Interfaces.Repositorios;
using apiFestivos.core.Interfaces.Servicios;
using apiFestivos.dominio.Entidades;

namespace apiFestivos.aplicacion.Servicios
{
    public class TipoServicio : ITipoServicio
    {
        private readonly ITipoRepositorio repositorio;

        public TipoServicio(ITipoRepositorio repositorio)
        {
            this.repositorio = repositorio;
        }

        public async Task<List<Tipo>> ObtenerTodos()
        {
            return await repositorio.ObtenerTodos();
        }

        public async Task<Tipo?> ObtenerPorId(int id)
        {
            return await repositorio.ObtenerPorId(id);
        }

        public async Task<Tipo> Crear(Tipo entidad)
        {
            return await repositorio.Crear(entidad);
        }

        public async Task<bool> Actualizar(Tipo entidad)
        {
            return await repositorio.Actualizar(entidad);
        }

        public async Task<bool> Eliminar(int id)
        {
            return await repositorio.Eliminar(id);
        }
    }
}
