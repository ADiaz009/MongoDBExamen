using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIseñoMongoDBExamen.Models
{
    public class ReporteAnalítico
    {
        [System.ComponentModel.DisplayName("Cliente")]
        public string Cliente { get; set; } = string.Empty;

        [System.ComponentModel.DisplayName("Nivel / Segmento")]
        public string Segmento { get; set; } = string.Empty; // Bronce, Plata, Oro, etc.

        // --- APLICACIÓN FINANCIERA (Rentabilidad) ---

        [System.ComponentModel.DisplayName("Total Facturado (C$)")]
        public decimal TotalGastado { get; set; }

        [System.ComponentModel.DisplayName("Frecuencia de Compra")]
        public int FrecuenciaVenta { get; set; } // Cuántas veces ha comprado

        [System.ComponentModel.DisplayName("Ahorro por Promos (C$)")]
        public decimal AhorroAcumulado { get; set; } // Diferencia entre subtotal y total pagado

        // --- TENDENCIAS COMERCIALES ---

        [System.ComponentModel.DisplayName("Estado de Rentabilidad")]
        public string EstadoRentabilidad { get; set; } = string.Empty; // "VIP / Alta", "Regular"

        [System.ComponentModel.DisplayName("Última Actividad")]
        public DateTime UltimaVisita { get; set; }
    }
}
