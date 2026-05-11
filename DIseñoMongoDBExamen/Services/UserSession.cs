using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIseñoMongoDBExamen.Services
{
    public class UserSession
    {
        public static Guid Id { get; set; }
        public static string Nombre { get; set; } = "Invitado";
        public static string Rol { get; set; } = "Ninguno";
        public static string SucursalNombre { get; set; } = "No asignada";
        public static Guid SucursalId { get; set; }
    }
}
