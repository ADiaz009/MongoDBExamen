    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    namespace DIseñoMongoDBExamen.Models
    {
        public class Promocion
        {
        public Guid Id { get; set; } = Guid.NewGuid();

        public string Nombre { get; set; } = string.Empty;

        public string Descripcion { get; set; } = string.Empty;

        public decimal PorcentajeDescuento { get; set; }

        public DateTime FechaInicio { get; set; } = DateTime.Now;

        public DateTime FechaFin { get; set; } = DateTime.Now.AddDays(7);

        public string CategoriaObjetivo { get; set; } = string.Empty;

        public bool Activa { get; set; } = true;
        }
    }
