using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoDBExamen.Schemes.DTOs
{
    public class SucursalDTO
    {
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Nombre { get; set; } = string.Empty;
        public string Ubicacion { get; set; } = string.Empty;
        public string Region { get; set; } = string.Empty; // Norte, Sur, Centro
        public string Telefono { get; set; } = string.Empty;
    }
}
