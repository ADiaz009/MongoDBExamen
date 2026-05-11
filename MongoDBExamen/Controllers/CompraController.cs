using Microsoft.AspNetCore.Mvc;
using MongoDBExamen.Interfaces;
using MongoDBExamen.Schemes.DTOs;

namespace MongoDBExamen.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CompraController : ControllerBase
    {
        private readonly ICompraRepository _repository;
        public CompraController(ICompraRepository repository) => _repository = repository;

        [HttpGet]
        public async Task<ActionResult<List<CompraDTO>>> GetAll() => await _repository.ObtenerTodosAsync();

        [HttpGet("{id}")]
        public async Task<ActionResult<CompraDTO>> GetById(Guid id)
        {
            var compra = await _repository.ObtenerPorIdAsync(id);
            return compra == null ? NotFound() : Ok(compra);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CompraDTO compra)
        {
            // El cálculo de IVA ya viene hecho desde el WinForms para mayor rapidez del usuario
            await _repository.CrearAsync(compra);
            return CreatedAtAction(nameof(GetById), new { id = compra.Id }, compra);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, CompraDTO compra)
        {
            var existe = await _repository.ObtenerPorIdAsync(id);
            if (existe == null) return NotFound();
            await _repository.ActualizarAsync(id, compra);
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

        // --- ENDPOINTS DE INTELIGENCIA COMERCIAL (Para Analistas y Dueños) ---

        [HttpGet("total-ingresos")]
        public async Task<ActionResult<decimal>> GetTotal() => await _repository.ObtenerIngresosTotalesAsync();

        [HttpGet("total-iva")] // Nuevo Endpoint
        public async Task<ActionResult<decimal>> GetTotalIva() => await _repository.ObtenerTotalIvaAsync();

        [HttpGet("ventas-por-categoria")]
        public async Task<ActionResult<Dictionary<string, decimal>>> GetPorCategoria()
            => await _repository.ObtenerVentasPorCategoriaAsync();

        [HttpGet("sucursal/{sucursalId}")]
        public async Task<List<CompraDTO>> GetBySucursal(Guid sucursalId)
            => await _repository.ObtenerPorSucursalAsync(sucursalId);
    }
}