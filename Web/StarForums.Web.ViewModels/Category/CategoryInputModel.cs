namespace StarForums.Web.ViewModels.Category
{
    using System.ComponentModel.DataAnnotations;

    public class CategoryInputModel
    {
        public int Id { get; set; }

        [Required]
        [MinLength(4, ErrorMessage = "Title must be at least 5 chars.")]
        [Display(Name = "Title")]
        public string Title { get; set; }

        [MaxLength(200, ErrorMessage = "Description shouldn't be longer than 200 chars.")]
        [Display(Name = "Description")]
        public string Description { get; set; }
    }
}
