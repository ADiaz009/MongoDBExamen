using MongoDB.Driver;
using MongoDBExamen.AppContext;
using MongoDBExamen.Interfaces;
using MongoDBExamen.Schemes.DTOs;

namespace MongoDBExamen.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly IMongoCollection<ClienteDTO> _collection;

        public ClienteRepository(MongoDBContext context)
        {
            _collection = context.Clientes;
        }

        public Task<List<ClienteDTO>> ObtenerTodosAsync() => _collection.Find(_ => true).ToListAsync();
        public Task<ClienteDTO> ObtenerPorIdAsync(Guid id) => _collection.Find(c => c.Id == id).FirstOrDefaultAsync();
        public Task CrearAsync(ClienteDTO entidad) => _collection.InsertOneAsync(entidad);
        public Task ActualizarAsync(Guid id, ClienteDTO entidad) => _collection.ReplaceOneAsync(c => c.Id == id, entidad);
        public Task EliminarAsync(Guid id) => _collection.DeleteOneAsync(c => c.Id == id);

        // Métodos Especializados (Inteligencia)
        public async Task AgregarPreferenciaAsync(Guid clienteId, string categoria)
        {
            var filter = Builders<ClienteDTO>.Filter.Eq(c => c.Id, clienteId);
            // AddToSet evita que se duplique la misma categoría en el arreglo
            var update = Builders<ClienteDTO>.Update.AddToSet(c => c.Preferencias, categoria);
            await _collection.UpdateOneAsync(filter, update);
        }

        public Task<List<ClienteDTO>> ObtenerClientesFrecuentesAsync()
        {
            // Filtramos por niveles altos para el análisis de rentabilidad
            return _collection.Find(c => c.Nivel == "Platino" || c.Nivel == "Oro").ToListAsync();
        }
    }
}
