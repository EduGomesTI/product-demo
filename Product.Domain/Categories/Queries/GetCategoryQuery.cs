using Microsoft.Extensions.Logging;
using Product.Domain.Categories.Entites;
using Product.Domain.Categories.Interfaces.Queries;
using Product.Domain.Categories.Interfaces.Repositories;

namespace Product.Domain.Categories.Queries
{
    public class GetCategoryQuery : IGetCategoryQuery
    {
        private readonly ILogger<GetAllCategoryQuery> _logger;
        private readonly ICategoryRepository<Category, int> _repository;

        public GetCategoryQuery(ILogger<GetAllCategoryQuery> logger, ICategoryRepository<Category, int> repository)
        {
            _logger = logger;
            _repository = repository;
        }

        public async Task<Category> Handle(Category category, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Get data from repossitory");
            return await _repository.GetAsync(category.Id, cancellationToken);
        }
    }
}
