using apiFestivos.core.Interfaces.Repositorios;
using apiFestivos.core.Interfaces.Servicios;
using apiFestivos.dominio.Entidades;

namespace apiFestivos.aplicacion.Servicios
{
    public class FestivoServicio : IFestivoServicio
    {
        private readonly IFestivoRepositorio repositorio;

        public FestivoServicio(IFestivoRepositorio repositorio)
        {
            this.repositorio = repositorio;
        }

        public async Task<List<Festivo>> ObtenerTodos()
        {
            return await repositorio.ObtenerTodos();
        }

        public async Task<Festivo?> ObtenerPorId(int id)
        {
            return await repositorio.ObtenerPorId(id);
        }

        public async Task<List<Festivo>> ObtenerPorPais(int idPais)
        {
            return await repositorio.ObtenerPorPais(idPais);
        }

        public async Task<Festivo> Crear(Festivo entidad)
        {
            return await repositorio.Crear(entidad);
        }

        public async Task<bool> Actualizar(Festivo entidad)
        {
            return await repositorio.Actualizar(entidad);
        }

        public async Task<bool> Eliminar(int id)
        {
            return await repositorio.Eliminar(id);
        }
    }
}
