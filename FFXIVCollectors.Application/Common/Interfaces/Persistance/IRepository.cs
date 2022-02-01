namespace FFXIVCollectors.Application.Common.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<TEntity> Get(int id);
        Task<TEntity> Add(TEntity entity);
        Task<IEnumerable<TEntity>> GetAll();
    }
}
