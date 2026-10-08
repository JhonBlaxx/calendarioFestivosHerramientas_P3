using apiFestivos.dominio.Entidades;

namespace apiFestivos.core.Interfaces.Repositorios
{
    public interface IPaisRepositorio
    {
        Task<List<Pais>> ObtenerTodos();
        Task<Pais?> ObtenerPorId(int id);
        Task<Pais> Crear(Pais entidad);
        Task<bool> Actualizar(Pais entidad);
        Task<bool> Eliminar(int id);
    }
}
