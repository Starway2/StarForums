namespace StarForums.Web.ViewModels.Comments
{
    using System.ComponentModel.DataAnnotations;

    public class CommentInputModel
    {
        public string PostTitle { get; set; }

        public int PostId { get; set; }

        [Required(ErrorMessage = "The comment must be at least 10 characters long.")]
        [Display(Name = "Content")]
        [MinLength(10)]
        public string Content { get; set; }

        public string UserId { get; set; }
    }
}
