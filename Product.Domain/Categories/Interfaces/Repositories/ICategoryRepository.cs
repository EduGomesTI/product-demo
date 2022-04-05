using Product.Domain.Bases.Entities;
using Product.Domain.Bases.Repositories;

namespace Product.Domain.Categories.Interfaces.Repositories
{
    public interface ICategoryRepository<TEntity, TId> :
        IReadRepository<TEntity, TId>,
        IWriteRepository<TEntity, TId>
        where TEntity : BaseEntity<TId>
    {

    }
}
