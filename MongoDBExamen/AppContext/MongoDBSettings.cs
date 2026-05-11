namespace MongoDBExamen.AppContext
{
    public class MongoDBSettings
    {
        public string ConnectionString { get; set; } = null!;
        public string DatabaseName { get; set; } = null!;

        // Mapeo de Colecciones para Inteligencia Comercial
        public string SucursalesCollection { get; set; } = null!;
        public string UsuariosCollection { get; set; } = null!;
        public string InventarioCollection { get; set; } = null!;
        public string ClientesCollection { get; set; } = null!;
        public string ComprasCollection { get; set; } = null!;
        public string PromocionesCollection { get; set; } = null!;
    }
}
