using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIseñoMongoDBExamen.Models
{
    public class Cliente
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Nombre { get; set; } = string.Empty;
        public string Apellidos { get; set; } = string.Empty;
        public string Correo { get; set; } = string.Empty;
        public string Nivel { get; set; } = "Bronce";
        public List<string> Preferencias { get; set; } = new List<string>();

        public string NombreCompleto => $"{Nombre} {Apellidos}";
    }
}
