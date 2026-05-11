using MongoDBExamen.Schemes.DTOs;

namespace MongoDBExamen.Interfaces
{
    public interface IInventarioRepository : IRepository<InventarioDTO>
    {
        Task<List<InventarioDTO>> ObtenerBajoStockAsync(int limite);
        Task<List<InventarioDTO>> ObtenerPorSucursalAsync(Guid sucursalId);
    }
}
