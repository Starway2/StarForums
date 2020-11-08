namespace StarForums.Web.ViewModels.Posts
{
    using Ganss.XSS;
    using StarForums.Data.Models;
    using StarForums.Services.Mapping;

    public class PostEditViewModel : IMapFrom<Post>
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public string CleanContent => new HtmlSanitizer().Sanitize(this.Content);

        public string UserId { get; set; }

        public ApplicationUser User { get; set; }

        public string ReturnUrl { get; set; }

    }
}
