using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIseñoMongoDBExamen.Models
{
    public class ItemCompra
    {
        public Guid ProductoId { get; set; }
        public string ProductoNombre { get; set; } = string.Empty;
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public string Categoria { get; set; } = string.Empty;
        public decimal SubtotalItem => Cantidad * PrecioUnitario;
    }
}
