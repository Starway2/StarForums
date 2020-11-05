namespace StarForums.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using StarForums.Services.Data;
    using StarForums.Web.ViewModels.Home;
    using StarForums.Web.ViewModels.Posts;

    public class CategoryController : BaseController
    {
        private readonly ICategoriesService categoriesService;
        private readonly IPostsService postsService;

        public CategoryController(ICategoriesService categoriesService, IPostsService postsService)
        {
            this.categoriesService = categoriesService;
            this.postsService = postsService;
        }

        [Route("/{categoryName}")]
        public IActionResult Index(string categoryName)
        {
            var category = this.categoriesService.GetByName<CategoryViewModel>(categoryName);

            if (category == null)
            {
                return this.NotFound();
            }

            var posts = this.postsService.GetByCategoryName<PostViewModel>(category.Name);
            category.Posts = posts;

            return this.View(category);
        }
    }
}
