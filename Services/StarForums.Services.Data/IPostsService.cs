namespace StarForums.Services.Data
{
    using StarForums.Web.ViewModels.Posts;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IPostsService
    {
        IEnumerable<T> GetAll<T>();

        T GetById<T>(int id);

        IEnumerable<T> GetByCategoryId<T>(int categoryId);

        IEnumerable<T> GetByCategoryName<T>(string categoryName);

        Task CreateAsync(CreatePostInputModel model);
    }
}
