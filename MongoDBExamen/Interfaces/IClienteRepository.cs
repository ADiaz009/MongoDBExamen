using MongoDB.Driver;
using MongoDBExamen.AppContext;
using MongoDBExamen.Schemes.DTOs;

namespace MongoDBExamen.Interfaces
{
    public interface IClienteRepository : IRepository<ClienteDTO>
    {
        // Método para ir alimentando los gustos del cliente dinámicamente
        Task AgregarPreferenciaAsync(Guid clienteId, string categoria);

        // Para identificar a los clientes más rentables
        Task<List<ClienteDTO>> ObtenerClientesFrecuentesAsync();
    }
}
