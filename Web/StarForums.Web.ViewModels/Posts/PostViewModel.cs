namespace StarForums.Web.ViewModels.Posts
{
    using StarForums.Data.Models;
    using StarForums.Services.Mapping;

    public class PostViewModel : IMapFrom<Post>
    {
        public string Title { get; set; }
    }
}
