using Microsoft.Extensions.Logging;
using Product.Domain.Categories.Entites;
using Product.Domain.Categories.Interfaces.Queries;
using Product.Domain.Categories.Interfaces.Repositories;

namespace Product.Domain.Categories.Queries
{
    public class GetAllCategoryQuery : IGetAllCategoryQuery
    {
        private readonly ILogger<GetAllCategoryQuery> _logger;
        private readonly ICategoryRepository<Category, int> _repository;

        public GetAllCategoryQuery(ILogger<GetAllCategoryQuery> logger, ICategoryRepository<Category, int> repository)
        {
            _logger = logger;
            _repository = repository;
        }

        public async Task<IEnumerable<Category>> Handle(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Get data from repository.");
            return await _repository.GetAllAsync(cancellationToken);
        }
    }
}
