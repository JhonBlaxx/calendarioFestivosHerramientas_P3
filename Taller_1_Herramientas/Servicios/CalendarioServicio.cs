using apiFestivos.dominio.Interfaces;
using apiFestivos.dominio.Entidades;

namespace Taller_1_Herramientas.Servicios
{
    public class CalendarioServicio : ICalendarioServicio
    {
        private readonly IFestivoRepositorio festivoRepositorio;

        public CalendarioServicio(IFestivoRepositorio festivoRepositorio)
        {
            this.festivoRepositorio = festivoRepositorio;
        }

        private DateTime CalcularDomingoPascua(int anio)
        {
            int a = anio % 19;
            int b = anio % 4;
            int c = anio % 7;
            int d = (19 * a + 24) % 30;
            int dias = d + ((2 * b + 4 * c + 6 * d + 5) % 7);

            DateTime domingoRamos = new DateTime(anio, 3, 15).AddDays(dias);
            DateTime domingoPascua = domingoRamos.AddDays(7);

            return domingoPascua;
        }

        private DateTime TrasladarLunes(DateTime fecha)
        {
            if (fecha.DayOfWeek == DayOfWeek.Monday)
            {
                return fecha;
            }

            int diasParaLunes = ((int)DayOfWeek.Monday - (int)fecha.DayOfWeek + 7) % 7;
            return fecha.AddDays(diasParaLunes);
        }

        private DateTime TrasladarViernes(DateTime fecha)
        {
            if (fecha.DayOfWeek == DayOfWeek.Friday)
            {
                return fecha;
            }

            int diasParaViernes = ((int)DayOfWeek.Friday - (int)fecha.DayOfWeek + 7) % 7;
            return fecha.AddDays(diasParaViernes);
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
                return TrasladarLunes(fecha);
            }

            if (festivo.IdTipo == 3)
            {
                return domingoPascua.AddDays(festivo.DiasPascua);
            }

            if (festivo.IdTipo == 4)
            {
                var fecha = domingoPascua.AddDays(festivo.DiasPascua);
                return TrasladarLunes(fecha);
            }

            if (festivo.IdTipo == 5)
            {
                var fecha = new DateTime(anio, festivo.Mes, festivo.Dia);
                return TrasladarViernes(fecha);
            }

            throw new Exception("No se sabe calcular este tipo de festivo: " + festivo.IdTipo);
        }

        private bool EsFechaValida(int anio, int mes, int dia)
        {
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
            var domingoPascua = CalcularDomingoPascua(anio);

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
            var festivos = await festivoRepositorio.ObtenerPorPais(idPais);
            var domingoPascua = CalcularDomingoPascua(anio);
            var lista = new List<FestivoFechaDTO>();

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
