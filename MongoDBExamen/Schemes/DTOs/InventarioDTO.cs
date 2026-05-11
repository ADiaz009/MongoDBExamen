using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoDBExamen.Schemes.DTOs
{
    public class InventarioDTO
    {
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        public Guid Id { get; set; } = Guid.NewGuid();
        public string NombreProducto { get; set; } = string.Empty;
        public string Categoria { get; set; } = string.Empty;
        public decimal Precio { get; set; }
        public int Stock { get; set; }
        public Guid SucursalId { get; set; } // Ubicación física del producto
    }
}
