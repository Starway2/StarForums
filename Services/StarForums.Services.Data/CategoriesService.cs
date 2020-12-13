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

        public IEnumerable<T> GetAll<T>() => this.repository.All().To<T>().ToList();

        public T GetById<T>(int id) => this.repository.All().Where(x => x.Id == id).To<T>().FirstOrDefault();

        public T GetByName<T>(string name) => this.repository.All().Where(x => x.Name.Replace(" ", "-") == name.Replace(" ", "-")).To<T>().FirstOrDefault();

        public async Task UpdateAsync(CategoryInputModel model)
        {
            var category = this.repository.All().Where(x => x.Id == model.Id).FirstOrDefault();

            category.Name = model.Title;
            category.Description = model.Description;

            this.repository.Update(category);
            await this.repository.SaveChangesAsync();
        }
    }
}
