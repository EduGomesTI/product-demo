using Product.Data.Base.Repositories;
using Product.Data.DataContext;
using Product.Domain.Categories.Entites;
using Product.Domain.Categories.Interfaces.Repositories;

namespace Product.Data.Repositories
{
    public class CategoryRepository
        : BaseRepository<MemoryContext, Category, int>,
        ICategoryRepository<Category, int>
    {
        public CategoryRepository(MemoryContext context) : base(context)
        {
        }
    }
}
