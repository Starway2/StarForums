namespace StarForums.Web.ViewModels.Posts
{
    using System.Collections.Generic;

    using Ganss.XSS;
    using StarForums.Data.Models;
    using StarForums.Services.Mapping;
    using StarForums.Web.ViewModels.Comments;

    public class PostViewModel : IMapFrom<Post>
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public string CleanContent => new HtmlSanitizer().Sanitize(this.Content);

        public string CategoryName { get; set; }

        public int CategoryId { get; set; }

        public string UserUserName { get; set; }

        public ApplicationUser User { get; set; }

        public IEnumerable<CommentViewModel> Comments { get; set; }
    }
}
