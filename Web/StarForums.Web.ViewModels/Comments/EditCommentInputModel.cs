namespace StarForums.Web.ViewModels.Comments
{
    using System.ComponentModel.DataAnnotations;
    using Ganss.XSS;
    using StarForums.Data.Models;
    using StarForums.Services.Mapping;

    public class EditCommentInputModel : IMapFrom<Comment>
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public int PostId { get; set; }

        public Post Post { get; set; }

        [Required]
        [MinLength(20)]
        public string Content { get; set; }

        public string CleanContent => new HtmlSanitizer().Sanitize(this.Content);
    }
}
