using Microsoft.AspNetCore.Mvc;
using apiFestivos.core.Interfaces.Servicios;
using apiFestivos.dominio.Entidades;

namespace apiFestivos.presentacion.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FestivoController : ControllerBase
    {
        private readonly IFestivoServicio servicio;

        public FestivoController(IFestivoServicio servicio)
        {
            this.servicio = servicio;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var lista = await servicio.ObtenerTodos();
            return Ok(lista);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var festivo = await servicio.ObtenerPorId(id);
            if (festivo == null)
            {
                return NotFound();
            }
            return Ok(festivo);
        }

        [HttpGet("pais/{idPais}")]
        public async Task<IActionResult> GetPorPais(int idPais)
        {
            var lista = await servicio.ObtenerPorPais(idPais);
            return Ok(lista);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Festivo festivo)
        {
            var creado = await servicio.Crear(festivo);
            return Ok(creado);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Festivo festivo)
        {
            if (id != festivo.Id)
            {
                return BadRequest();
            }

            var ok = await servicio.Actualizar(festivo);
            if (!ok)
            {
                return NotFound();
            }
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var ok = await servicio.Eliminar(id);
            if (!ok)
            {
                return NotFound();
            }
            return Ok();
        }
    }
}
