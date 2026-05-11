using MongoDBExamen.Schemes.DTOs;

namespace MongoDBExamen.Interfaces
{
    public interface ISucursalRepository : IRepository<SucursalDTO>
    {
        // Podés agregar métodos como obtener por región específica
        Task<List<SucursalDTO>> ObtenerPorRegionAsync(string region);
    }
}
