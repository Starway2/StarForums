namespace StarForums.Web.ViewModels.Home
{
    using System.Collections.Generic;
    using Ganss.XSS;
    using StarForums.Data.Models;
    using StarForums.Services.Mapping;
    using StarForums.Web.ViewModels.Posts;

    public class CategoryViewModel : IMapFrom<Category>
    {
        public CategoryViewModel()
        {
            this.Posts = new HashSet<PostViewModel>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string CleanDescription => new HtmlSanitizer().Sanitize(this.Description);

        public IEnumerable<PostViewModel> Posts { get; set; }
    }
}
