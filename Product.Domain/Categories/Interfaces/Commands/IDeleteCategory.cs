using Product.Domain.Categories.Entites;

namespace Product.Domain.Categories.Interfaces.Commands
{
    public interface IDeleteCategory
    {
        Task Handle(Category category);
    }
}
