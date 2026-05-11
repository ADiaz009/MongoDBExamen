using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoDBExamen.Schemes.DTOs
{
    public class PromocionDTO
    {
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        public Guid Id { get; set; } = Guid.NewGuid();

        // Cambiamos a 'Nombre' para que coincida con el txtNombre del UI
        public string Nombre { get; set; } = string.Empty;

        public string Descripcion { get; set; } = string.Empty;

        // Cambiamos a 'PorcentajeDescuento' para que sea más descriptivo
        public decimal PorcentajeDescuento { get; set; }

        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }

        // Este lo podés usar para el "NivelRequerido" (Bronce, Oro, etc.)
        public string CategoriaObjetivo { get; set; } = string.Empty;

        public bool Activa { get; set; } = true;
    }
}
