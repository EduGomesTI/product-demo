using FluentValidation;
using Microsoft.Extensions.Logging;
using Product.Domain.Bases.Error;
using Product.Domain.Categories.Entites;
using Product.Domain.Categories.Interfaces.Commands;
using Product.Domain.Categories.Interfaces.Repositories;

namespace Product.Domain.Categories.Commands
{
    public class SaveCategoryCommand : ISaveCategoryCommand
    {
        private readonly ICategoryRepository<Category, int> _repository;
        private readonly ILogger<SaveCategoryCommand> _logger;
        private readonly IValidator<Category> _validator;

        public SaveCategoryCommand(ICategoryRepository<Category, int> repository, ILogger<SaveCategoryCommand> logger, IValidator<Category> validattor)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _validator = validattor ?? throw new ArgumentNullException(nameof(validattor));
        }

        public async Task Handle(Category category)
        {
            _logger.LogInformation("Step 1 - Validate request and set to object.");
            var validationResult = await _validator.ValidateAsync(category, opt =>
            {
                opt.IncludeRuleSets("Add");
            });

            category.ValidationResult = validationResult;

            if (!category.ValidationResult.IsValid)
            {
                _logger.LogError(category.ValidationResult.ToString());
                throw new InvalidValidationResultException("Validation Error.", category.ValidationResult);
            }

            _logger.LogInformation("Step 2 - Call Repository.");
            try
            {
                await _repository.SaveAsync(category);
            }
            catch (Exception ex)
            {
                _logger?.LogError(ex.ToString());
                throw;
            }

        }
    }
}
