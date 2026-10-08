using apiFestivos.core.Interfaces.Repositorios;
using apiFestivos.core.Interfaces.Servicios;
using apiFestivos.dominio.DTOs;
using apiFestivos.dominio.Entidades;

namespace apiFestivos.aplicacion.Servicios
{
    public class CalendarioServicio : ICalendarioServicio
    {
        private readonly IFestivoRepositorio festivoRepositorio;

        public CalendarioServicio(IFestivoRepositorio festivoRepositorio)
        {
            this.festivoRepositorio = festivoRepositorio;
        }

        private DateTime SiguienteViernes(DateTime fecha)
        {
            int diasViernes = ((int)DayOfWeek.Friday - (int)fecha.DayOfWeek + 7) % 7;
            return ServicioFechas.AgregarDias(fecha, diasViernes);
        }

        private DateTime CalcularFecha(Festivo festivo, int anio, DateTime domingoPascua)
        {
            if (festivo.IdTipo == 1)
            {
                return new DateTime(anio, festivo.Mes, festivo.Dia);
            }

            if (festivo.IdTipo == 2)
            {
                var fecha = new DateTime(anio, festivo.Mes, festivo.Dia);
                return ServicioFechas.SiguienteLunes(fecha);
            }

            if (festivo.IdTipo == 3)
            {
                return ServicioFechas.AgregarDias(domingoPascua, festivo.DiasPascua);
            }

            if (festivo.IdTipo == 4)
            {
                var fecha = ServicioFechas.AgregarDias(domingoPascua, festivo.DiasPascua);
                return ServicioFechas.SiguienteLunes(fecha);
            }

            if (festivo.IdTipo == 5)
            {
                var fecha = new DateTime(anio, festivo.Mes, festivo.Dia);
                return SiguienteViernes(fecha);
            }

            throw new Exception("No se sabe calcular este tipo de festivo: " + festivo.IdTipo);
        }

        private bool EsFechaValida(int anio, int mes, int dia)
        {
            if (anio < 1 || anio > 9999)
            {
                return false;
            }

            if (mes < 1 || mes > 12)
            {
                return false;
            }

            if (dia < 1 || dia > DateTime.DaysInMonth(anio, mes))
            {
                return false;
            }

            return true;
        }

        public async Task<string> VerificarFecha(int idPais, int anio, int mes, int dia)
        {
            if (!EsFechaValida(anio, mes, dia))
            {
                return "Fecha No valida";
            }

            var fecha = new DateTime(anio, mes, dia);
            var festivos = await festivoRepositorio.ObtenerPorPais(idPais);
            var domingoPascua = ServicioFechas.ObtenerPascua(anio);

            foreach (var festivo in festivos)
            {
                var fechaFestivo = CalcularFecha(festivo, anio, domingoPascua);
                if (fechaFestivo.Date == fecha.Date)
                {
                    return "Es Festivo";
                }
            }

            return "No es festivo";
        }

        public async Task<List<FestivoFechaDTO>> ListarFestivos(int idPais, int anio)
        {
            var lista = new List<FestivoFechaDTO>();

            if (anio < 1 || anio > 9999)
            {
                return lista;
            }

            var festivos = await festivoRepositorio.ObtenerPorPais(idPais);
            var domingoPascua = ServicioFechas.ObtenerPascua(anio);

            foreach (var festivo in festivos)
            {
                var fechaFestivo = CalcularFecha(festivo, anio, domingoPascua);
                lista.Add(new FestivoFechaDTO
                {
                    Festivo = festivo.Nombre,
                    Fecha = fechaFestivo.ToString("yyyy-MM-dd")
                });
            }

            return lista.OrderBy(f => f.Fecha).ToList();
        }
    }
}
