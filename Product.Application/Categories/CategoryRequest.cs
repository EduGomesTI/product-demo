using Product.Application.Bases;

namespace Product.Application.Categories
{
    public struct CategoryRequest : IRequest
    {
        public int Id { get; set; }
        public string Description { get; set; }
    }
}
