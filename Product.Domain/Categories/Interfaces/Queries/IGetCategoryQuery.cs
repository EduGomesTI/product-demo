using Product.Domain.Categories.Entites;

namespace Product.Domain.Categories.Interfaces.Queries
{
    public interface IGetCategoryQuery
    {
        Task<Category> Handle(Category category, CancellationToken cancellationToken);
    }
}
