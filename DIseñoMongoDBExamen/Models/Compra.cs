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

        public decimal Subtotal { get; set; }

        public decimal Iva { get; set; }

        public decimal Total { get; set; }

        public List<ItemCompra> Items { get; set; } = new();
    }
}
