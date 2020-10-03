namespace StarForums.Web.ViewModels.Home
{
    using System.Collections.Generic;

    using StarForums.Data.Models;
    using StarForums.Services.Mapping;
    using StarForums.Web.ViewModels.Posts;

    public class CategoryViewModel : IMapFrom<Category>
    {
        public CategoryViewModel()
        {
            this.Posts = new HashSet<PostViewModel>();
        }

        public string Name { get; set; }

        public string Description { get; set; }

        public ICollection<PostViewModel> Posts { get; set; }
    }
}
