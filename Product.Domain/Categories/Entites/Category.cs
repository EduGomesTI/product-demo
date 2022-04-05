using Product.Domain.Bases.Entities;

namespace Product.Domain.Categories.Entites
{
    public class Category : BaseEntity<int>
    {
        public string? Description { get; set; }
    }
}
