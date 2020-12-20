namespace StarForums.Web.ViewModels.Messages
{
    using System.ComponentModel.DataAnnotations;

    public class MessageInputModel
    {
        [Required(ErrorMessage = "{0} is required!")]
        [MinLength(3)]
        [MaxLength(60, ErrorMessage = "Title must not exceed {0} characters")]
        public string Title { get; set; }

        [Required(ErrorMessage = "{0} must be at least 3 charachters long")]
        [MinLength(3)]
        [MaxLength(1000, ErrorMessage = "Content must not exceed {0} characters")]
        public string Content { get; set; }

        [Required(ErrorMessage = "{0} is required!")]
        [Display(Name = "Recipient Username")]
        public string ReceiverUsername { get; set; }

        [Required]
        public string SenderUsername { get; set; }
    }
}
