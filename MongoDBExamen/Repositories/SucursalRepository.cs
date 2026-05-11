using MongoDB.Driver;
using MongoDBExamen.AppContext;
using MongoDBExamen.Interfaces;
using MongoDBExamen.Schemes.DTOs;

namespace MongoDBExamen.Repositories
{
    public class SucursalRepository : ISucursalRepository
    {
        private readonly IMongoCollection<SucursalDTO> _collection;

        public SucursalRepository(MongoDBContext context)
        {
            _collection = context.Sucursales;
        }

        public Task<List<SucursalDTO>> ObtenerTodosAsync() => _collection.Find(_ => true).ToListAsync();
        public Task<SucursalDTO> ObtenerPorIdAsync(Guid id) => _collection.Find(s => s.Id == id).FirstOrDefaultAsync();
        public Task CrearAsync(SucursalDTO entidad) => _collection.InsertOneAsync(entidad);
        public Task ActualizarAsync(Guid id, SucursalDTO entidad) => _collection.ReplaceOneAsync(s => s.Id == id, entidad);
        public Task EliminarAsync(Guid id) => _collection.DeleteOneAsync(s => s.Id == id);

        // Especializado: Para el análisis regional
        public Task<List<SucursalDTO>> ObtenerPorRegionAsync(string region)
        {
            return _collection.Find(s => s.Region == region).ToListAsync();
        }
    }
}
