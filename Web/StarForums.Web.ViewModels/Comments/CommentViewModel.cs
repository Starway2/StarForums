namespace StarForums.Web.ViewModels.Comments
{
    using Ganss.XSS;
    using StarForums.Data.Models;
    using StarForums.Services.Mapping;
    using System;

    public class CommentViewModel : IMapFrom<Comment>
    {
        public string Content { get; set; }

        public string CleanContent => new HtmlSanitizer().Sanitize(this.Content);

        public int PostId { get; set; }

        public string UserId { get; set; }

        public DateTime CreatedOn { get; set; }

        public ApplicationUser User { get; set; }
    }
}