namespace StarForums.Web.ViewModels.Posts
{
    using System.ComponentModel.DataAnnotations;

    using StarForums.Data.Models;

    public class CreatePostInputModel
    {
        [Required]
        [MaxLength(100)]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        public int CategoryId { get; set; }

        public string UserId { get; set; }
    }
}
