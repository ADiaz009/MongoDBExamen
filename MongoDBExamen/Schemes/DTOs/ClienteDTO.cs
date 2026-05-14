using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.Serializers;



namespace MongoDBExamen.Schemes.DTOs
{
    public class ClienteDTO
    {
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Nombre { get; set; } = string.Empty;
        public string Apellidos { get; set; } = string.Empty;
        public string Correo { get; set; } = string.Empty;
        public string Nivel { get; set; } = "Bronce"; // Bronce, Oro, Platino

        // Arreglo dinámico para tendencias y hábitos
        public List<string> Preferencias { get; set; } = new List<string>();
    }
}
