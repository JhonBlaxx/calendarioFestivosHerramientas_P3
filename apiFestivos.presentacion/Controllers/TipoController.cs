using Microsoft.AspNetCore.Mvc;
using apiFestivos.core.Interfaces.Servicios;
using apiFestivos.dominio.Entidades;

namespace apiFestivos.presentacion.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TipoController : ControllerBase
    {
        private readonly ITipoServicio servicio;

        public TipoController(ITipoServicio servicio)
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
            var tipo = await servicio.ObtenerPorId(id);
            if (tipo == null)
            {
                return NotFound();
            }
            return Ok(tipo);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Tipo tipo)
        {
            var creado = await servicio.Crear(tipo);
            return Ok(creado);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Tipo tipo)
        {
            if (id != tipo.Id)
            {
                return BadRequest();
            }

            var ok = await servicio.Actualizar(tipo);
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
