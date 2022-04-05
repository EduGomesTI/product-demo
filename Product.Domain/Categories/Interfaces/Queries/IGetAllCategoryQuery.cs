using Product.Domain.Categories.Entites;

namespace Product.Domain.Categories.Interfaces.Queries
{
    public interface IGetAllCategoryQuery
    {
        Task<IEnumerable<Category>> Handle(CancellationToken cancellationToken);
    }
}
