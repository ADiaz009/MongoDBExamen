namespace MongoDBExamen.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<List<T>> ObtenerTodosAsync();
        Task<T> ObtenerPorIdAsync(Guid id);
        Task CrearAsync(T entidad);
        Task ActualizarAsync(Guid id, T entidad);
        Task EliminarAsync(Guid id);
    }
}
