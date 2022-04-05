using Microsoft.Extensions.Logging;
using Product.Application.Bases;
using Product.Domain.Categories.Interfaces.Commands;
using Product.Domain.Categories.Interfaces.Queries;

namespace Product.Application.Categories
{
    public class CategoryService : IBaseService<CategoryRequest, CategoryReponse, int>
    {
        private readonly ILogger<CategoryService> _logger;
        private readonly IGetAllCategoryQuery _getAll;
        private readonly IGetCategoryQuery _get;
        private readonly ISaveCategoryCommand _save;

        public CategoryService(ILogger<CategoryService> logger, IGetAllCategoryQuery getAll, IGetCategoryQuery get, ISaveCategoryCommand save)
        {
            _logger = logger;
            _getAll = getAll;
            _get = get;
            _save = save;
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<CategoryReponse>> GetAllAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Step 1 - Get data from Query.");
            var categories = await _getAll.Handle(cancellationToken);

            _logger.LogInformation("Step 2 - Map class to reponse and return data.");
            var response = categories.Select(cat => CategoryMap.Response(cat));

            return response;
        }

        public async Task<CategoryReponse> GetAsync(int id, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Step 1 - create a reques.t");
            var request = new CategoryRequest() { Id = id };

            _logger.LogInformation("Step 2 - Map request to class.");
            var category = CategoryMap.Category(request);

            _logger.LogInformation("Step 3 - Get data from Query.");
            category = await _get.Handle(category, cancellationToken);

            _logger.LogInformation("Step 4 - Map class to response and return data.");
            var response = CategoryMap.Response(category);

            return response;
        }

        public async Task SaveAsync(CategoryRequest request)
        {
            _logger.LogInformation("Step 1 - Map request to class.");
            var category = CategoryMap.Category(request);

            _logger.LogInformation("Step 2 - Call Command to save data.");
            await _save.Handle(category);


        }

        public Task UpdateAsync(CategoryRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
