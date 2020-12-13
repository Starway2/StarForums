namespace StarForums.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using StarForums.Web.ViewModels.Comments;

    public interface ICommentsService
    {
        IEnumerable<T> GetAll<T>(int postId);

        IEnumerable<T> GetByUserId<T>(string userId);

        T GetById<T>(int commentId);

        Task EditCommentAsync(int commentId, string content);

        Task AddCommentAsync(CommentInputModel model);

        Task<int> DeleteComment(int id);
    }
}
