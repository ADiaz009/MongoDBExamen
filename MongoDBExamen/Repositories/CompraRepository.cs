using MongoDB.Driver;
using MongoDBExamen.AppContext;
using MongoDBExamen.Interfaces;
using MongoDBExamen.Schemes.DTOs;

namespace MongoDBExamen.Repositories
{
    public class CompraRepository : ICompraRepository
    {
        private readonly IMongoCollection<CompraDTO> _collection;

        public CompraRepository(MongoDBContext context)
        {
            _collection = context.Compras;
        }

        public Task<List<CompraDTO>> ObtenerTodosAsync() => _collection.Find(_ => true).ToListAsync();
        public Task<CompraDTO> ObtenerPorIdAsync(Guid id) => _collection.Find(c => c.Id == id).FirstOrDefaultAsync();
        public Task CrearAsync(CompraDTO entidad) => _collection.InsertOneAsync(entidad);
        public Task ActualizarAsync(Guid id, CompraDTO entidad) => _collection.ReplaceOneAsync(c => c.Id == id, entidad);
        public Task EliminarAsync(Guid id) => _collection.DeleteOneAsync(c => c.Id == id);

        public Task<List<CompraDTO>> ObtenerPorSucursalAsync(Guid sucursalId)
        {
            return _collection.Find(c => c.SucursalId == sucursalId).ToListAsync();
        }

        // --- REPORTES FINANCIEROS ACTUALIZADOS ---

        public async Task<decimal> ObtenerIngresosTotalesAsync()
        {
            var todas = await _collection.Find(_ => true).ToListAsync();
            // Retorna el Total (Subtotal + IVA)
            return todas.Sum(c => c.Total);
        }

        public async Task<decimal> ObtenerTotalIvaAsync()
        {
            var todas = await _collection.Find(_ => true).ToListAsync();
            // Retorna solo el acumulado de impuestos para el reporte fiscal
            return todas.Sum(c => c.Iva);
        }

        public async Task<Dictionary<string, decimal>> ObtenerVentasPorCategoriaAsync()
        {
            var compras = await _collection.Find(_ => true).ToListAsync();

            return compras
                .SelectMany(c => c.Items)
                .GroupBy(i => i.Categoria)
                .ToDictionary(
                    g => g.Key,
                    g => g.Sum(x => x.PrecioUnitario * x.Cantidad) // Ganancia bruta por categoría
                );
        }
    }
}