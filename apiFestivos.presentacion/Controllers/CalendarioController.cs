using Microsoft.AspNetCore.Mvc;
using apiFestivos.core.Interfaces.Servicios;

namespace apiFestivos.presentacion.Controllers
{
    [ApiController]
    [Route("api/calendario")]
    public class CalendarioController : ControllerBase
    {
        private readonly ICalendarioServicio servicio;

        public CalendarioController(ICalendarioServicio servicio)
        {
            this.servicio = servicio;
        }

        [HttpGet("verificar/{idPais}/{anio}/{mes}/{dia}")]
        public async Task<IActionResult> Verificar(int idPais, int anio, int mes, int dia)
        {
            var resultado = await servicio.VerificarFecha(idPais, anio, mes, dia);
            return Ok(resultado);
        }

        [HttpGet("festivos/{idPais}/{anio}")]
        public async Task<IActionResult> Festivos(int idPais, int anio)
        {
            var resultado = await servicio.ListarFestivos(idPais, anio);
            return Ok(resultado);
        }
    }
}
