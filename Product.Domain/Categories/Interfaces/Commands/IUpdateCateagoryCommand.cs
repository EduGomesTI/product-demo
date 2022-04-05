using Product.Domain.Categories.Entites;

namespace Product.Domain.Categories.Interfaces.Commands
{
    public interface IUpdateCateagoryCommand
    {
        Task Handle(Category category);
    }
}
