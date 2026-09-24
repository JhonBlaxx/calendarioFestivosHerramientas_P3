using Microsoft.AspNetCore.Mvc;
using apiFestivos.dominio.Interfaces;

namespace Taller_1_Herramientas.Controllers
{
    [ApiController]
    [Route("api/calendario")]
    public class CalendarioController : ControllerBase
    {
        private readonly ICalendarioServicio calendarioServicio;

        public CalendarioController(ICalendarioServicio calendarioServicio)
        {
            this.calendarioServicio = calendarioServicio;
        }

        [HttpGet("verificar/{idPais}/{anio}/{mes}/{dia}")]
        public async Task<IActionResult> Verificar(int idPais, int anio, int mes, int dia)
        {
            var resultado = await calendarioServicio.VerificarFecha(idPais, anio, mes, dia);
            return Ok(resultado);
        }

        [HttpGet("festivos/{idPais}/{anio}")]
        public async Task<IActionResult> Festivos(int idPais, int anio)
        {
            var resultado = await calendarioServicio.ListarFestivos(idPais, anio);
            return Ok(resultado);
        }
    }
}
