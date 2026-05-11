namespace MongoDBExamen.Schemes.DTOs
{
    public class ItemCompraDTO
    {
        public Guid productoId { get; set; }
        public string ProductoNombre { get; set; } = string.Empty;
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public string Categoria { get; set; } = string.Empty;
        public decimal SubtotalItem => Cantidad * PrecioUnitario;
    }
}
