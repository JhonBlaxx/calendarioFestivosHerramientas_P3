using Microsoft.AspNetCore.Mvc;
using apiFestivos.dominio.Entidades;
using apiFestivos.dominio.Interfaces;

namespace Taller_1_Herramientas.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TipoController : ControllerBase
    {
        private readonly ITipoRepositorio repositorio;

        public TipoController(ITipoRepositorio repositorio)
        {
            this.repositorio = repositorio;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var lista = await repositorio.ObtenerTodos();
            return Ok(lista);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var tipo = await repositorio.ObtenerPorId(id);
            if (tipo == null)
            {
                return NotFound();
            }
            return Ok(tipo);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Tipo tipo)
        {
            var creado = await repositorio.Crear(tipo);
            return Ok(creado);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Tipo tipo)
        {
            if (id != tipo.Id)
            {
                return BadRequest();
            }

            var ok = await repositorio.Actualizar(tipo);
            if (!ok)
            {
                return NotFound();
            }
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var ok = await repositorio.Eliminar(id);
            if (!ok)
            {
                return NotFound();
            }
            return Ok();
        }
    }
}
