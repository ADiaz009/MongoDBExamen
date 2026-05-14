using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoDBExamen.Schemes.DTOs
{
    public class ItemCompraDTO
    {
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        public Guid productoId { get; set; }
        public string ProductoNombre { get; set; } = string.Empty;
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public string Categoria { get; set; } = string.Empty;
        public decimal SubtotalItem => Cantidad * PrecioUnitario;
    }
}
