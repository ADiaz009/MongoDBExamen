using Microsoft.AspNetCore.Mvc;
using MongoDBExamen.Interfaces;
using MongoDBExamen.Schemes.DTOs;

namespace MongoDBExamen.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClienteController : Controller
    {
        private readonly IClienteRepository _repository;
        public ClienteController(IClienteRepository repository) => _repository = repository;

        [HttpGet]
        public async Task<List<ClienteDTO>> GetAll() => await _repository.ObtenerTodosAsync();

        [HttpGet("{id}")]
        public async Task<ActionResult<ClienteDTO>> GetById(Guid id)
        {
            var cliente = await _repository.ObtenerPorIdAsync(id);
            return cliente == null ? NotFound() : Ok(cliente);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ClienteDTO cliente)
        {
            await _repository.CrearAsync(cliente);
            return CreatedAtAction(nameof(GetById), new { id = cliente.Id }, cliente);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, ClienteDTO cliente)
        {
            var existe = await _repository.ObtenerPorIdAsync(id);
            if (existe == null) return NotFound();
            await _repository.ActualizarAsync(id, cliente);
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

        // --- MÉTODO PARA INTELIGENCIA DE HÁBITOS ---
        [HttpPatch("{id}/preferencias")]
        public async Task<IActionResult> PatchPreferencia(Guid id, [FromBody] string categoria)
        {
            await _repository.AgregarPreferenciaAsync(id, categoria);
            return Ok();
        }
    }
}
