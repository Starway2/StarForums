namespace StarForums.Web.ViewModels.Comments
{
    using System.ComponentModel.DataAnnotations;
    using Ganss.XSS;
    using StarForums.Data.Models;
    using StarForums.Services.Mapping;

    public class EditCommentInputModel : IMapFrom<Comment>
    {
        public string PostTitle { get; set; }

        [Required]
        public int Id { get; set; }

        [Required]
        public int PostId { get; set; }

        public Post Post { get; set; }

        [Required(ErrorMessage = "The comment must be at least 10 characters long.")]
        [Display(Name = "Content")]
        [MinLength(10)]
        public string Content { get; set; }

        public string CleanContent => new HtmlSanitizer().Sanitize(this.Content);
    }
}
