using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoDBExamen.Schemes.DTOs
{
    public class CompraDTO
    {
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid ClienteId { get; set; }
        public Guid SucursalId { get; set; }
        public DateTime Fecha { get; set; } = DateTime.Now;
        [BsonRepresentation(BsonType.Decimal128)]
        public decimal Subtotal { get; set; }

        [BsonRepresentation(BsonType.Decimal128)]
        public decimal Iva { get; set; } // IVA del 15%

        [BsonRepresentation(BsonType.Decimal128)]
        public decimal Total { get; set; }

        // Lista embebida de productos comprados (Comportamiento Comercial)
        public List<ItemCompraDTO> Items { get; set; } = new List<ItemCompraDTO>();
    }
}
