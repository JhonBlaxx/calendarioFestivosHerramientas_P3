using Microsoft.AspNetCore.Mvc;
using apiFestivos.dominio.Entidades;
using apiFestivos.dominio.Interfaces;

namespace Taller_1_Herramientas.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PaisController : ControllerBase
    {
        private readonly IPaisRepositorio repositorio;

        public PaisController(IPaisRepositorio repositorio)
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
            var pais = await repositorio.ObtenerPorId(id);
            if (pais == null)
            {
                return NotFound();
            }
            return Ok(pais);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Pais pais)
        {
            var creado = await repositorio.Crear(pais);
            return Ok(creado);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Pais pais)
        {
            if (id != pais.Id)
            {
                return BadRequest();
            }

            var ok = await repositorio.Actualizar(pais);
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
