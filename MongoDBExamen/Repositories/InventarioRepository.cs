using MongoDB.Driver;
using MongoDBExamen.AppContext;
using MongoDBExamen.Interfaces;
using MongoDBExamen.Schemes.DTOs;

namespace MongoDBExamen.Repositories
{
    public class InventarioRepository : IInventarioRepository
    {
        private readonly IMongoCollection<InventarioDTO> _collection;

        public InventarioRepository(MongoDBContext context)
        {
            _collection = context.Inventario;
        }

        public Task<List<InventarioDTO>> ObtenerTodosAsync() => _collection.Find(_ => true).ToListAsync();
        public Task<InventarioDTO> ObtenerPorIdAsync(Guid id) => _collection.Find(i => i.Id == id).FirstOrDefaultAsync();
        public Task CrearAsync(InventarioDTO entidad) => _collection.InsertOneAsync(entidad);
        public Task ActualizarAsync(Guid id, InventarioDTO entidad) => _collection.ReplaceOneAsync(i => i.Id == id, entidad);
        public Task EliminarAsync(Guid id) => _collection.DeleteOneAsync(i => i.Id == id);

        // Especializado: Para saber qué reponer (Estadística de Consumo)
        public Task<List<InventarioDTO>> ObtenerBajoStockAsync(int limite)
        {
            return _collection.Find(i => i.Stock <= limite).ToListAsync();
        }

        public Task<List<InventarioDTO>> ObtenerPorSucursalAsync(Guid sucursalId)
        {
            return _collection.Find(i => i.SucursalId == sucursalId).ToListAsync();
        }
    }
}
