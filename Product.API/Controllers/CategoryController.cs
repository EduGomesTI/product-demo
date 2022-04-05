using Microsoft.AspNetCore.Mvc;
using Product.Application.Bases;
using Product.Application.Categories;

namespace Product.API.Controllers
{
    [Route("v{version:apiVersion}/[controller]")]
    [ApiVersion("1", Deprecated = false)]
    [ApiController]
    [ApiExplorerSettings(GroupName = "v1")]
    public class CategoryController : BaseControllerV1<CategoryRequest, CategoryReponse, int>
    {
        public CategoryController(IBaseService<CategoryRequest, CategoryReponse, int> service) : base(service)
        {
        }
    }
}
