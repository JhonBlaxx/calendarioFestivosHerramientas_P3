using apiFestivos.dominio.Entidades;

namespace apiFestivos.dominio.Interfaces
{
    public interface ICalendarioServicio
    {
        Task<string> VerificarFecha(int idPais, int anio, int mes, int dia);
        Task<List<FestivoFechaDTO>> ListarFestivos(int idPais, int anio);
    }
}
