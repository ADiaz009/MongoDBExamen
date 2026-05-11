using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIseñoMongoDBExamen.Models
{
    public class Compra
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid ClienteId { get; set; }
        public Guid SucursalId { get; set; }
        public DateTime Fecha { get; set; } = DateTime.Now;
        public decimal Subtotal { get; set; } // Suma de productos sin IVA
        public decimal IVA { get; set; }      // El 15% del Subtotal
        public decimal Total { get; set; }
        public List<ItemCompra> Items { get; set; } = new List<ItemCompra>();
    }
}
