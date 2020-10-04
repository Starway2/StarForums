namespace StarForums.Services.Data
{
    using System.Collections.Generic;

    public interface IPostsService
    {
        IEnumerable<T> GetAll<T>();

        T GetById<T>(int id);

        IEnumerable<T> GetByCategoryId<T>(int categoryId);

        IEnumerable<T> GetByCategoryName<T>(string categoryName);
    }
}
