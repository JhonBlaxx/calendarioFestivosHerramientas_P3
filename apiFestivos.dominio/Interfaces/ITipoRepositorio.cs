using apiFestivos.dominio.Entidades;

namespace apiFestivos.dominio.Interfaces
{
    public interface ITipoRepositorio
    {
        Task<List<Tipo>> ObtenerTodos();
        Task<Tipo?> ObtenerPorId(int id);
        Task<Tipo> Crear(Tipo tipo);
        Task<bool> Actualizar(Tipo tipo);
        Task<bool> Eliminar(int id);
    }
}
