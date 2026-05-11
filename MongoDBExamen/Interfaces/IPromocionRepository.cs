using MongoDBExamen.Schemes.DTOs;

namespace MongoDBExamen.Interfaces
{
    public interface IPromocionRepository : IRepository<PromocionDTO>
    {
        Task<List<PromocionDTO>> ObtenerPromocionesActivasAsync();
    }
}
