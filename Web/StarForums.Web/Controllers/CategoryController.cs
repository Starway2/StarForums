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

            return this.View();
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

            return this.RedirectToAction("Index", "Home");
        }

        [Authorize]
        public IActionResult Edit(string title)
        {
            if (!this.User.IsInRole(GlobalConstants.AdministratorRoleName))
            {
                return this.StatusCode(403);
            }

            var query = this.categoriesService.GetByName<CategoryViewModel>(title);

            if (query == null)
            {
                return this.NotFound();
            }

            var category = new CategoryInputModel() { Title = query.Name, Description = query.Description, Id = query.Id };

            return this.View(category);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Edit(CategoryInputModel model)
        {
            if (!this.User.IsInRole(GlobalConstants.AdministratorRoleName))
            {
                return this.StatusCode(403);
            }

            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            await this.categoriesService.UpdateAsync(model);

            return this.RedirectToAction("Index", new { categoryName = model.Title});
        }
    }
}
