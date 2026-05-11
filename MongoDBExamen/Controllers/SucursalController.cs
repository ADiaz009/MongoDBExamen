using Microsoft.AspNetCore.Mvc;
using MongoDBExamen.Interfaces;
using MongoDBExamen.Schemes.DTOs;

namespace MongoDBExamen.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SucursalController : Controller
    {
        private readonly ISucursalRepository _repository;
        public SucursalController(ISucursalRepository repository) => _repository = repository;

        [HttpGet]
        public async Task<ActionResult<List<SucursalDTO>>> GetAll() => await _repository.ObtenerTodosAsync();

        [HttpGet("{id}")]
        public async Task<ActionResult<SucursalDTO>> GetById(Guid id)
        {
            var sucursal = await _repository.ObtenerPorIdAsync(id);
            return sucursal == null ? NotFound() : Ok(sucursal);
        }

        [HttpPost]
        public async Task<IActionResult> Create(SucursalDTO sucursal)
        {
            await _repository.CrearAsync(sucursal);
            return CreatedAtAction(nameof(GetById), new { id = sucursal.Id }, sucursal);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, SucursalDTO sucursal)
        {
            var existe = await _repository.ObtenerPorIdAsync(id);
            if (existe == null) return NotFound();
            await _repository.ActualizarAsync(id, sucursal);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var existe = await _repository.ObtenerPorIdAsync(id);
            if (existe == null) return NotFound();
            await _repository.EliminarAsync(id);
            return NoContent();
        }

        // REPORTE: Filtrar por región (Análisis Regional)
        [HttpGet("region/{nombreRegion}")]
        public async Task<List<SucursalDTO>> GetByRegion(string nombreRegion)
            => await _repository.ObtenerPorRegionAsync(nombreRegion);
    }
}
