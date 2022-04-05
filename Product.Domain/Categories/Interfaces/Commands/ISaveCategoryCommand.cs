using Product.Domain.Categories.Entites;

namespace Product.Domain.Categories.Interfaces.Commands
{
    public interface ISaveCategoryCommand
    {
        Task Handle(Category category);
    }
}
