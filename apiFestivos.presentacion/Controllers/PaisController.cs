using Microsoft.AspNetCore.Mvc;
using apiFestivos.core.Interfaces.Servicios;
using apiFestivos.dominio.Entidades;

namespace apiFestivos.presentacion.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PaisController : ControllerBase
    {
        private readonly IPaisServicio servicio;

        public PaisController(IPaisServicio servicio)
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
            var pais = await servicio.ObtenerPorId(id);
            if (pais == null)
            {
                return NotFound();
            }
            return Ok(pais);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Pais pais)
        {
            var creado = await servicio.Crear(pais);
            return Ok(creado);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Pais pais)
        {
            if (id != pais.Id)
            {
                return BadRequest();
            }

            var ok = await servicio.Actualizar(pais);
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
