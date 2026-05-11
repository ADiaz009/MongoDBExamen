using Microsoft.AspNetCore.Mvc;
using MongoDBExamen.Interfaces;
using MongoDBExamen.Schemes.DTOs;

namespace MongoDBExamen.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InventarioController : Controller
    {
        private readonly IInventarioRepository _repository;
        public InventarioController(IInventarioRepository repository) => _repository = repository;

        [HttpGet]
        public async Task<ActionResult<List<InventarioDTO>>> GetAll() => await _repository.ObtenerTodosAsync();

        [HttpGet("{id}")]
        public async Task<ActionResult<InventarioDTO>> GetById(Guid id)
        {
            var item = await _repository.ObtenerPorIdAsync(id);
            return item == null ? NotFound() : Ok(item);
        }

        [HttpPost]
        public async Task<IActionResult> Create(InventarioDTO item)
        {
            await _repository.CrearAsync(item);
            return CreatedAtAction(nameof(GetById), new { id = item.Id }, item);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, InventarioDTO item)
        {
            var existe = await _repository.ObtenerPorIdAsync(id);
            if (existe == null) return NotFound();
            await _repository.ActualizarAsync(id, item);
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

        // --- MÉTODOS ESTADÍSTICOS ---

        [HttpGet("stock-bajo/{limite}")]
        public async Task<List<InventarioDTO>> GetBajoStock(int limite)
            => await _repository.ObtenerBajoStockAsync(limite);

        [HttpGet("sucursal/{sucursalId}")]
        public async Task<List<InventarioDTO>> GetBySucursal(Guid sucursalId)
            => await _repository.ObtenerPorSucursalAsync(sucursalId);
    }
}

