using apiFestivos.dominio.Entidades;

namespace apiFestivos.core.Interfaces.Servicios
{
    public interface ITipoServicio
    {
        Task<List<Tipo>> ObtenerTodos();
        Task<Tipo?> ObtenerPorId(int id);
        Task<Tipo> Crear(Tipo entidad);
        Task<bool> Actualizar(Tipo entidad);
        Task<bool> Eliminar(int id);
    }
}
