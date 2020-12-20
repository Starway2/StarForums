namespace StarForums.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using StarForums.Data.Common.Models;

    public class Message : BaseDeletableModel<int>
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public string ReceiverId { get; set; }

        public virtual ApplicationUser Receiver { get; set; }

        [Required]
        public string SenderId { get; set; }

        public virtual ApplicationUser Sender { get; set; }
    }
}
