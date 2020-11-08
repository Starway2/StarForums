namespace StarForums.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using StarForums.Web.ViewModels.Posts;

    public interface IPostsService
    {
        IEnumerable<T> GetAll<T>();

        T GetById<T>(int id);

        IEnumerable<T> GetByCategoryId<T>(int categoryId);

        IEnumerable<T> GetByCategoryName<T>(string categoryName);

        IEnumerable<T> GetByUserId<T>(string userId);

        Task<int> CreateAsync(CreatePostInputModel model);

        Task DeleteAsync(int postId);

        Task EditAsync(int postId, string title, string content);
    }
}
