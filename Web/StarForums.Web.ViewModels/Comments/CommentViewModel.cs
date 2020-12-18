namespace StarForums.Web.ViewModels.Comments
{
    using System;

    using Ganss.XSS;
    using StarForums.Data.Models;
    using StarForums.Services.Mapping;

    public class CommentViewModel : IMapFrom<Comment>
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public string CleanContent => new HtmlSanitizer().Sanitize(this.Content);

        public int PostId { get; set; }

        public string UserId { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime ModifiedOn { get; set; }

        public string UserUsername { get; set; }

        public int UserPostsCount { get; set; }

        public int UserCommentsCount { get; set; }

        public string UserAvatarUrl { get; set; }

        public string UserSignature { get; set; }

        public string CleanSignature => new HtmlSanitizer().Sanitize(this.UserSignature);

        public ApplicationUser User { get; set; }
    }
}