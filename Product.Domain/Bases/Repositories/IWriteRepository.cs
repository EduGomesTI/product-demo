using Product.Domain.Bases.Entities;

namespace Product.Domain.Bases.Repositories
{
    public interface IWriteRepository<TEntity, TId> where TEntity : BaseEntity<TId>
    {
        Task SaveAsync(TEntity entity);
        Task DeleteAsync(TId id);
        Task UpdateAsync(TEntity entity);
    }
}
