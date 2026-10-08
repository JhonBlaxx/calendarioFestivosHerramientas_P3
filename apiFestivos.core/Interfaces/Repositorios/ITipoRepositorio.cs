using apiFestivos.dominio.Entidades;

namespace apiFestivos.core.Interfaces.Repositorios
{
    public interface ITipoRepositorio
    {
        Task<List<Tipo>> ObtenerTodos();
        Task<Tipo?> ObtenerPorId(int id);
        Task<Tipo> Crear(Tipo entidad);
        Task<bool> Actualizar(Tipo entidad);
        Task<bool> Eliminar(int id);
    }
}
