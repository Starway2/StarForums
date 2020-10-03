namespace StarForums.Services.Data
{
    using StarForums.Data.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ICategoriesService
    {
        IEnumerable<T> GetAll<T>();

        Category GetById<T>(int id);
    }
}
