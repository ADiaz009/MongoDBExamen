using MongoDB.Driver;
using MongoDBExamen.AppContext;
using MongoDBExamen.Interfaces;
using MongoDBExamen.Schemes.DTOs;

namespace MongoDBExamen.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly IMongoCollection<UsuarioDTO> _collection;

        public UsuarioRepository(MongoDBContext context)
        {
            _collection = context.Usuarios;
        }

        public Task<List<UsuarioDTO>> ObtenerTodosAsync() => _collection.Find(_ => true).ToListAsync();
        public Task<UsuarioDTO> ObtenerPorIdAsync(Guid id) => _collection.Find(u => u.Id == id).FirstOrDefaultAsync();
        public Task CrearAsync(UsuarioDTO entidad) => _collection.InsertOneAsync(entidad);
        public Task ActualizarAsync(Guid id, UsuarioDTO entidad) => _collection.ReplaceOneAsync(u => u.Id == id, entidad);
        public Task EliminarAsync(Guid id) => _collection.DeleteOneAsync(u => u.Id == id);

        public Task<UsuarioDTO> LoginAsync(string username, string password)
        {
            // Simple validación de login
            return _collection.Find(u => u.NombreUsuario == username && u.Password == password).FirstOrDefaultAsync();
        }
    }
}
