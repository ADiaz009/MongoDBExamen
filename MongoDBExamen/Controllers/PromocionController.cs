using Microsoft.AspNetCore.Mvc;
using MongoDBExamen.Interfaces;
using MongoDBExamen.Schemes.DTOs;

namespace MongoDBExamen.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PromocionController : Controller
    {
        private readonly IPromocionRepository _repository;
        public PromocionController(IPromocionRepository repository) => _repository = repository;

        [HttpGet]
        public async Task<List<PromocionDTO>> GetAll() => await _repository.ObtenerTodosAsync();

        [HttpGet("{id}")]
        public async Task<ActionResult<PromocionDTO>> GetById(Guid id)
        {
            var promo = await _repository.ObtenerPorIdAsync(id);
            return promo == null ? NotFound() : Ok(promo);
        }

        [HttpPost]
        public async Task<IActionResult> Create(PromocionDTO promo)
        {
            await _repository.CrearAsync(promo);
            return CreatedAtAction(nameof(GetById), new { id = promo.Id }, promo);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, PromocionDTO promo)
        {
            var existe = await _repository.ObtenerPorIdAsync(id);
            if (existe == null) return NotFound();
            await _repository.ActualizarAsync(id, promo);
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
    }
}
