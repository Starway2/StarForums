namespace StarForums.Web.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using StarForums.Common;
    using StarForums.Services.Data;
    using StarForums.Web.ViewModels.Category;
    using StarForums.Web.ViewModels.Home;
    using StarForums.Web.ViewModels.Posts;

    public class CategoryController : Controller
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

            category.Posts = this.postsService.GetByCategoryName<PostViewModel>(category.Name);

            category.Posts = category.Posts.OrderByDescending(x => x.CreatedOn);

            return this.View(category);
        }

        [Authorize]
        public IActionResult Create()
        {
            if (!this.User.IsInRole(GlobalConstants.AdministratorRoleName))
            {
                return this.StatusCode(403);
            }
            var model = new CategoryInputModel() { Exist = false };

            return this.View(model);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(CategoryInputModel model)
        {
            if (!this.User.IsInRole(GlobalConstants.AdministratorRoleName))
            {
                return this.StatusCode(403);
            }

            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            var result = await this.categoriesService.CreateAsync(model);

            if (!result)
            {
                model.Exist = true;
                return this.View(model);
            }

            return this.RedirectToAction("Index", "Home");
        }
    }
}
