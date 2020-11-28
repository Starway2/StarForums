namespace StarForums.Web.ViewModels.Comments
{
    using System.ComponentModel.DataAnnotations;

    public class CommentInputModel
    {
        [Required]
        public int PostId { get; set; }

        [Required]
        [MinLength(20)]
        public string Content { get; set; }

        [Required]
        public string UserId { get; set; }
    }
}
