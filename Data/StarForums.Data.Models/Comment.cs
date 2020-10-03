namespace StarForums.Data.Models
{
    using StarForums.Data.Common.Models;

    public class Comment : BaseDeletableModel<int>
    {
        public string Content { get; set; }

        public int PostId { get; set; }

        public virtual Post Post { get; set; }

        public virtual ApplicationUser User { get; set; }
    }
}