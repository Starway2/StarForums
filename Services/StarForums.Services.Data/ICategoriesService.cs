namespace StarForums.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using StarForums.Web.ViewModels.Category;

    public interface ICategoriesService
    {
        IEnumerable<T> GetAll<T>();

        T GetById<T>(int id);

        T GetByName<T>(string name);

        Task<bool> CreateAsync(CategoryInputModel model);

        Task UpdateAsync(CategoryInputModel model);
    }
}
