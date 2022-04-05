using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Product.Application.Bases;
using Product.Application.Categories;
using Product.Data.DataContext;
using Product.Data.Repositories;
using Product.Domain.Categories.Commands;
using Product.Domain.Categories.Entites;
using Product.Domain.Categories.Interfaces.Commands;
using Product.Domain.Categories.Interfaces.Queries;
using Product.Domain.Categories.Interfaces.Repositories;
using Product.Domain.Categories.Queries;
using Product.Domain.Categories.Validators;

namespace Product.CrossCutting
{
    public static class DependencyInjection
    {
        public static void CategoryDependecyInjection(this IServiceCollection services)
        {
            services.AddDbContext<MemoryContext>(opt => opt.UseInMemoryDatabase("Products"));
            services.AddScoped<MemoryContext>();
            services.AddScoped<ISaveCategoryCommand, SaveCategoryCommand>();
            services.AddScoped<ICategoryRepository<Category, int>, CategoryRepository>();
            services.AddScoped<IValidator<Category>, CategoryValidator>();
            services.AddScoped<IBaseService<CategoryRequest, CategoryReponse, int>, CategoryService>();
            services.AddScoped<IGetAllCategoryQuery, GetAllCategoryQuery>();
            services.AddScoped<IGetCategoryQuery, GetCategoryQuery>();
            services.AddScoped<ISaveCategoryCommand, SaveCategoryCommand>();
        }
    }
}
