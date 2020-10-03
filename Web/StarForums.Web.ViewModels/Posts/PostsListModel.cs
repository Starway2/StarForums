namespace StarForums.Web.ViewModels.Posts
{
    using System.Collections.Generic;

    public class PostsListModel
    {
        public ICollection<PostViewModel> Posts { get; set; }
    }
}
