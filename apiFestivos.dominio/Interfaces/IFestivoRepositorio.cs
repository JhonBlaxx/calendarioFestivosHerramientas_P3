using apiFestivos.dominio.Entidades;

namespace apiFestivos.dominio.Interfaces
{
    public interface IFestivoRepositorio
    {
        Task<List<Festivo>> ObtenerTodos();
        Task<Festivo?> ObtenerPorId(int id);
        Task<List<Festivo>> ObtenerPorPais(int idPais);
        Task<Festivo> Crear(Festivo festivo);
        Task<bool> Actualizar(Festivo festivo);
        Task<bool> Eliminar(int id);
    }
}
