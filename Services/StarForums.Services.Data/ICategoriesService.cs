namespace StarForums.Services.Data
{
    using System.Collections.Generic;

    using StarForums.Data.Models;

    public interface ICategoriesService
    {
        IEnumerable<T> GetAll<T>();

        Category GetById(int id);

        Category GetByName(string name);
    }
}
