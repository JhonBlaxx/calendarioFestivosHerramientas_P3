using apiFestivos.dominio.Entidades;

namespace apiFestivos.dominio.Interfaces
{
    public interface IPaisRepositorio
    {
        Task<List<Pais>> ObtenerTodos();
        Task<Pais?> ObtenerPorId(int id);
        Task<Pais> Crear(Pais pais);
        Task<bool> Actualizar(Pais pais);
        Task<bool> Eliminar(int id);
    }
}
