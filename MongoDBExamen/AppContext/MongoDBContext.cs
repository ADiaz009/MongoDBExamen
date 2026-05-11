using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDBExamen.Schemes.DTOs;

namespace MongoDBExamen.AppContext
{
    public class MongoDBContext
    {
        private readonly IMongoDatabase _database;

        public MongoDBContext(IOptions<MongoDBSettings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            _database = client.GetDatabase(settings.Value.DatabaseName);
        }

        public IMongoCollection<SucursalDTO> Sucursales => _database.GetCollection<SucursalDTO>("Sucursales");
        public IMongoCollection<UsuarioDTO> Usuarios => _database.GetCollection<UsuarioDTO>("Usuarios");
        public IMongoCollection<InventarioDTO> Inventario => _database.GetCollection<InventarioDTO>("Inventario");
        public IMongoCollection<ClienteDTO> Clientes => _database.GetCollection<ClienteDTO>("Clientes");
        public IMongoCollection<CompraDTO> Compras => _database.GetCollection<CompraDTO>("Compras");
        public IMongoCollection<PromocionDTO> Promociones => _database.GetCollection<PromocionDTO>("Promociones");
    }
}
