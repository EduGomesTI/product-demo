using Product.Domain.Categories.Entites;

namespace Product.Application.Categories
{
    public static class CategoryMap
    {

        public static CategoryRequest Request(Category category)
        {
            return new CategoryRequest
            {
                Id = category.Id,
                Description = category.Description
            };
        }

        public static CategoryReponse Response(Category category)
        {
            return new CategoryReponse
            {
                Id = category.Id,
                Description = category.Description
            };
        }

        public static Category Category(CategoryRequest request)
        {
            return new Category
            {
                Description = request.Description,
                Id = request.Id
            };
        }

        public static Category Category(CategoryReponse reponse)
        {
            return new Category
            {
                Description = reponse.Description,
                Id = reponse.Id
            };
        }
    }
}
