using apiFestivos.dominio.DTOs;

namespace apiFestivos.core.Interfaces.Servicios
{
    public interface ICalendarioServicio
    {
        Task<string> VerificarFecha(int idPais, int anio, int mes, int dia);
        Task<List<FestivoFechaDTO>> ListarFestivos(int idPais, int anio);
    }
}
