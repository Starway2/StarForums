namespace StarForums.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using StarForums.Data.Common.Repositories;
    using StarForums.Data.Models;
    using StarForums.Services.Mapping;
    using StarForums.Web.ViewModels.Comments;

    public class CommentsService : ICommentsService
    {
        private readonly IDeletableEntityRepository<Comment> repository;

        public CommentsService(IDeletableEntityRepository<Comment> repository)
        {
            this.repository = repository;
        }

        public async Task AddCommentAsync(CommentInputModel model)
        {
            var comment = new Comment()
            {
                Content = model.Content,
                PostId = model.PostId,
                UserId = model.UserId,
            };

            await this.repository.AddAsync(comment);
            await this.repository.SaveChangesAsync();
        }

        public async Task EditCommentAsync(int commentId, string content)
        {
            var comment = this.repository.All().Where(x => x.Id == commentId).FirstOrDefault();
            comment.Content = content;
            this.repository.Update(comment);
            await this.repository.SaveChangesAsync();
        }

        public IEnumerable<T> GetAll<T>(int postId) => this.repository.All().Where(x => x.PostId == postId).OrderBy(x => x.CreatedOn).To<T>().ToList();

        public T GetById<T>(int commentId) => this.repository.All().Where(x => x.Id == commentId).To<T>().FirstOrDefault();

        public IEnumerable<T> GetByUserId<T>(string userId) => this.repository.All().Where(x => x.UserId == userId).To<T>().ToList();
    }
}
