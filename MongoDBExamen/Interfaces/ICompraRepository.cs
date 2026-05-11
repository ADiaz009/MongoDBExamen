using MongoDBExamen.Schemes.DTOs;

namespace MongoDBExamen.Interfaces
{
    public interface ICompraRepository : IRepository<CompraDTO>
    {
        // Esto sí es de compras: segmentación por sucursal
        Task<List<CompraDTO>> ObtenerPorSucursalAsync(Guid sucursalId);

        Task<decimal> ObtenerIngresosTotalesAsync(); // Suma de Totales
        Task<decimal> ObtenerTotalIvaAsync();

        // Esto sí es de compras: tendencias comerciales por categoría
        Task<Dictionary<string, decimal>> ObtenerVentasPorCategoriaAsync();
    }
}
