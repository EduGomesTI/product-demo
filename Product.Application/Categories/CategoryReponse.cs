using Product.Application.Bases;

namespace Product.Application.Categories
{
    public class CategoryReponse : IResponse
    {
        public int Id { get; set; }
        public string? Description { get; set; }
    }
}
