using MongoDBExamen.Schemes.DTOs;

namespace MongoDBExamen.Interfaces
{
    public interface IUsuarioRepository : IRepository<UsuarioDTO>
    {
        Task<UsuarioDTO> LoginAsync(string username, string password);
    }
}
