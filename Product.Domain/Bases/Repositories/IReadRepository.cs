using Product.Domain.Bases.Entities;

namespace Product.Domain.Bases.Repositories
{
    public interface IReadRepository<TEntity, TId> where TEntity : BaseEntity<TId>
    {
        Task<TEntity> GetAsync(TId id, CancellationToken cancellationToken);
        Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken cancellationToken);
    }
}
