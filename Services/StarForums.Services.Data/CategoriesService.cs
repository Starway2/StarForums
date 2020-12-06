namespace StarForums.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using StarForums.Data.Common.Repositories;
    using StarForums.Data.Models;
    using StarForums.Services.Mapping;
    using StarForums.Web.ViewModels.Category;

    public class CategoriesService : ICategoriesService
    {
        private readonly IRepository<Category> repository;

        public CategoriesService(IRepository<Category> repository)
        {
            this.repository = repository;
        }

        public async Task<bool> CreateAsync(CategoryInputModel model)
        {
            var categories = this.repository.All().Where(x => x.Name.ToLower() == model.Title.ToLower());

            if (categories.Any())
            {
                return false;
            }

            var category = new Category()
            {
                Name = model.Title,
                Description = model.Description,
            };

            await this.repository.AddAsync(category);
            await this.repository.SaveChangesAsync();

            return true;
        }

        public IEnumerable<T> GetAll<T>()
        {
            IQueryable<Category> query = this.repository.All();

            return query.To<T>().ToList();
        }

        public T GetById<T>(int id)
        {
            var category = this.repository.All().Where(x => x.Id == id);
            return category.To<T>().FirstOrDefault();
        }

        public T GetByName<T>(string name)
        {
            var category = this.repository.All().Where(x => x.Name.Replace(" ", "-") == name.Replace(" ", "-")).To<T>().FirstOrDefault();

            return category;
        }
    }
}
