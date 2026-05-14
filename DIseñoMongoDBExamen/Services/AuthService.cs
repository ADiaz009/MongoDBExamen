using DIseñoMongoDBExamen.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIseñoMongoDBExamen.Services
{
    public class AuthService
    {
        // Aquí guardamos al usuario que inició sesión
        public static Usuario UsuarioActual { get; set; }

        // Definición de Roles (Constantes para no cometer errores de dedo)
        public const string ROL_CEO = "CEO";
        public const string ROL_ADMIN = "Administrador";
        public const string ROL_TECNICO = "Técnico";
        public const string ROL_VENDEDOR = "Vendedor";
        public const string ROL_ANALISTA = "Analista";

        public static bool TienePermiso(params string[] rolesPermitidos)
        {
            if (UsuarioActual == null) return false;
            foreach (var rol in rolesPermitidos)
            {
                if (UsuarioActual.Rol == rol) return true;
            }
            return false;
        }

        // Método para saber si es "Staff de Poder" (Dueño o Admin)
        public static bool EsAdminODueño() => TienePermiso(ROL_CEO, ROL_ADMIN);
    }
}
