using Microsoft.EntityFrameworkCore;
using Product.Domain.Bases.Entities;
using Product.Domain.Bases.Repositories;

namespace Product.Data.Base.Repositories
{
    public abstract class BaseRepository<TContext, TEntity, TId>
        : IReadRepository<TEntity, TId>,
        IWriteRepository<TEntity, TId>
        where TEntity : BaseEntity<TId>
        where TContext : DbContext
    {
        private readonly TContext _context;

        protected BaseRepository(TContext context)
        {
            _context = context;
        }

        public async Task DeleteAsync(TId id)
        {
            _context.Remove(id);

            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken cancellationToken)
        {
            var result = await CreateSet().ToListAsync(cancellationToken);

            return result;
        }

        public async Task<TEntity> GetAsync(TId id, CancellationToken cancellationToken)
        {
            var result = await CreateSet()
                .Where(e => e.Id.Equals(id))
                .FirstOrDefaultAsync(cancellationToken);

            return result;
        }

        public async Task SaveAsync(TEntity entity)
        {
            await _context.AddAsync(entity);

            await _context.SaveChangesAsync();
        }

        public Task UpdateAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }

        #region Methods

        private DbSet<TEntity> CreateSet()
        {
            return _context.Set<TEntity>();
        }

        public async Task<int> CommitAsync(CancellationToken cancellationToken)
        {
            return await _context.SaveChangesAsync(cancellationToken);
        }

        public void MarkAs(TEntity entity, EntityState state)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            _context.Entry(entity).State = state;
        }

        public void Attach(TEntity entity)
        {
            MarkAs(entity, EntityState.Unchanged);
        }

        #endregion
    }
}
