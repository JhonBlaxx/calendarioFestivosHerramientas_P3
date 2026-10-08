using apiFestivos.dominio.Entidades;

namespace apiFestivos.core.Interfaces.Servicios
{
    public interface IPaisServicio
    {
        Task<List<Pais>> ObtenerTodos();
        Task<Pais?> ObtenerPorId(int id);
        Task<Pais> Crear(Pais entidad);
        Task<bool> Actualizar(Pais entidad);
        Task<bool> Eliminar(int id);
    }
}
