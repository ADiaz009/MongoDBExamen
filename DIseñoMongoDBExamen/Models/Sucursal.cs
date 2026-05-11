using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIseñoMongoDBExamen.Models
{
    public class Sucursal
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Nombre { get; set; } = string.Empty;
        public string Ubicacion { get; set; } = string.Empty;
        public string Region { get; set; } = string.Empty;
        public string Telefono { get; set; } = string.Empty;

        // Para que se vea bonito en los ComboBox
        public override string ToString() => Nombre;
    }
}
