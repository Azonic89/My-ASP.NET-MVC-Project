using System.Linq;

using Bytes2you.Validation;

using CarSystem.Data.Contracts;
using CarSystem.Data.Models;
using CarSystem.Data.Services.Contracts;

namespace CarSystem.Data.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IEfCarSystemDataProvider<Category> categoryDataProvider;

        public CategoryService(IEfCarSystemDataProvider<Category> categoryDataProvider)
        {
            Guard.WhenArgument(categoryDataProvider, nameof(categoryDataProvider)).IsNull().Throw();

            this.categoryDataProvider = categoryDataProvider;
        }

        public IQueryable<Category> GetAllCategories()
        {
            return this.categoryDataProvider.All();
        }

        public Category GetById(int id)
        {
            return this.categoryDataProvider.GetById(id);
        }
    }
}
