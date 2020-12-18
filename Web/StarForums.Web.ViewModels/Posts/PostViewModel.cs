namespace StarForums.Web.ViewModels.Posts
{
    using System;
    using System.Collections.Generic;

    using Ganss.XSS;
    using StarForums.Data.Models;
    using StarForums.Services.Mapping;
    using StarForums.Web.ViewModels.Comments;

    public class PostViewModel : IMapFrom<Post>
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime ModifiedOn { get; set; }

        public string Content { get; set; }

        public string CleanContent => new HtmlSanitizer().Sanitize(this.Content);

        public string CategoryName { get; set; }

        public int CategoryId { get; set; }

        public string UserSignature { get; set; }

        public string CleanSignature => new HtmlSanitizer().Sanitize(this.UserSignature);

        public string UserUserName { get; set; }

        public int UserPostsCount { get; set; }

        public string UserAvatarUrl { get; set; }

        public ApplicationUser User { get; set; }

        public int UserCommentsCount { get; set; }

        public IEnumerable<CommentViewModel> Comments { get; set; }
    }
}
