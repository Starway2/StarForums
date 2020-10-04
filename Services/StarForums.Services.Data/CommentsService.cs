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

        public async Task AddComment(CommentInputModel model)
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

        public IEnumerable<T> GetAll<T>(int postId)
        {
            return this.repository.All().Where(x => x.PostId == postId).To<T>().ToList();
        }
    }
}
