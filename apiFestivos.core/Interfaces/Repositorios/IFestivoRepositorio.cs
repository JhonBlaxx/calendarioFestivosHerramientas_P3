using apiFestivos.dominio.Entidades;

namespace apiFestivos.core.Interfaces.Repositorios
{
    public interface IFestivoRepositorio
    {
        Task<List<Festivo>> ObtenerTodos();
        Task<Festivo?> ObtenerPorId(int id);
        Task<List<Festivo>> ObtenerPorPais(int idPais);
        Task<Festivo> Crear(Festivo entidad);
        Task<bool> Actualizar(Festivo entidad);
        Task<bool> Eliminar(int id);
    }
}
