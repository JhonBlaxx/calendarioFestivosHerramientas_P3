using Microsoft.AspNetCore.Mvc;
using apiFestivos.dominio.Entidades;
using apiFestivos.dominio.Interfaces;

namespace Taller_1_Herramientas.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FestivoController : ControllerBase
    {
        private readonly IFestivoRepositorio repositorio;

        public FestivoController(IFestivoRepositorio repositorio)
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
            var festivo = await repositorio.ObtenerPorId(id);
            if (festivo == null)
            {
                return NotFound();
            }
            return Ok(festivo);
        }

        [HttpGet("pais/{idPais}")]
        public async Task<IActionResult> GetPorPais(int idPais)
        {
            var lista = await repositorio.ObtenerPorPais(idPais);
            return Ok(lista);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Festivo festivo)
        {
            var creado = await repositorio.Crear(festivo);
            return Ok(creado);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Festivo festivo)
        {
            if (id != festivo.Id)
            {
                return BadRequest();
            }

            var ok = await repositorio.Actualizar(festivo);
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
