using Microsoft.AspNetCore.Mvc;
using MongoDBExamen.Interfaces;
using MongoDBExamen.Schemes.DTOs;

namespace SistemaComercial.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepository _repository;

        public UsuarioController(IUsuarioRepository repository)
        {
            _repository = repository;
        }

        // --- CRUD COMPLETO ---

        [HttpGet]
        public async Task<ActionResult<List<UsuarioDTO>>> GetAll() => await _repository.ObtenerTodosAsync();

        [HttpGet("{id}")]
        public async Task<ActionResult<UsuarioDTO>> GetById(Guid id)
        {
            var usuario = await _repository.ObtenerPorIdAsync(id);
            return usuario == null ? NotFound() : Ok(usuario);
        }

        [HttpPost]
        public async Task<IActionResult> Create(UsuarioDTO usuario)
        {
            try
            {
                await _repository.CrearAsync(usuario);
                return Ok(usuario);
            }
            catch (Exception ex)
            {
                // Esto te va a devolver el mensaje REAL del error en el cuerpo de la respuesta 500
                return StatusCode(500, $"Error real: {ex.Message} | Inner: {ex.InnerException?.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, UsuarioDTO usuario)
        {
            var existe = await _repository.ObtenerPorIdAsync(id);
            if (existe == null) return NotFound();

            await _repository.ActualizarAsync(id, usuario);
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

        // --- LOGIN (CORREGIDO) ---

        [HttpPost("login")]
        public async Task<ActionResult<UsuarioDTO>> Login([FromBody] LoginRequest request)
        {
            // Usamos NombreUsuario para que coincida con el DTO y el Repo
            var usuario = await _repository.LoginAsync(request.NombreUsuario, request.Password);

            if (usuario == null) return Unauthorized(new { message = "Credenciales incorrectas, dog" });

            return Ok(usuario);
        }
    }

    // Clase de apoyo para el Login con los nombres correctos
    public class LoginRequest
    {
        public string NombreUsuario { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}