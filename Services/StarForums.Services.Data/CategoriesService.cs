namespace StarForums.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using StarForums.Data.Common.Repositories;
    using StarForums.Data.Models;
    using StarForums.Services.Mapping;

    public class CategoriesService : ICategoriesService
    {
        private readonly IRepository<Category> repository;

        public CategoriesService(IRepository<Category> repository)
        {
            this.repository = repository;
        }

        public IEnumerable<T> GetAll<T>()
        {
            IQueryable<Category> query = this.repository.All();

            return query.To<T>().ToList();
        }

        public Category GetById(int id)
        {
            return this.repository.All().Where(c => c.Id == id).FirstOrDefault();
        }

        public Category GetByName(string name)
        {
            return this.repository.All().Where(c => c.Name == name).FirstOrDefault();
        }
    }
}
