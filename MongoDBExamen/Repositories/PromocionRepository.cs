using MongoDB.Driver;
using MongoDBExamen.AppContext;
using MongoDBExamen.Interfaces;
using MongoDBExamen.Schemes.DTOs;

namespace MongoDBExamen.Repositories
{
    public class PromocionRepository : IPromocionRepository
    {
        private readonly IMongoCollection<PromocionDTO> _collection;

        public PromocionRepository(MongoDBContext context)
        {
            _collection = context.Promociones;
        }

        public Task<List<PromocionDTO>> ObtenerTodosAsync() => _collection.Find(_ => true).ToListAsync();
        public Task<PromocionDTO> ObtenerPorIdAsync(Guid id) => _collection.Find(p => p.Id == id).FirstOrDefaultAsync();
        public Task CrearAsync(PromocionDTO entidad) => _collection.InsertOneAsync(entidad);
        public Task ActualizarAsync(Guid id, PromocionDTO entidad) => _collection.ReplaceOneAsync(p => p.Id == id, entidad);
        public Task EliminarAsync(Guid id) => _collection.DeleteOneAsync(p => p.Id == id);

        public Task<List<PromocionDTO>> ObtenerPromocionesActivasAsync()
        {
            return _collection.Find(p => p.Activa == true).ToListAsync();
        }
    }
}
