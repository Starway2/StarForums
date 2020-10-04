namespace StarForums.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using StarForums.Data.Common.Models;

    public class Post : BaseDeletableModel<int>
    {
        [Required]
        [MaxLength(100)]
        public string Title { get; set; }

        public string Content { get; set; }

        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }

        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
    }
}
