namespace StarForums.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using StarForums.Data.Models;
    using StarForums.Services.Data;
    using StarForums.Web.ViewModels.Home;
    using StarForums.Web.ViewModels.Posts;
    using System.Threading.Tasks;

    public class PostController : Controller
    {
        private readonly IPostsService postsService;
        private readonly ICategoriesService categoriesService;
        private readonly UserManager<ApplicationUser> userManager;

        public PostController(IPostsService postsService, ICategoriesService categoriesService, UserManager<ApplicationUser> userManager)
        {
            this.postsService = postsService;
            this.categoriesService = categoriesService;
            this.userManager = userManager;
        }

        [Route("/{categoryName}/{postId}")]
        public IActionResult Index(int postId)
        {
            var post = this.postsService.GetById<PostViewModel>(postId);

            return this.View(post);
        }

        [Route("/{categoryName}/Create")]
        [Authorize]
        public IActionResult Create(string categoryName)
        {
            var model = new CreatePostInputModel();

            var test = this.categoriesService.GetByName<CategoryViewModel>(categoryName);

            model.CategoryId = test.Id;

            return this.View(model);
        }

        [Route("/{categoryName}/Create")]
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create(CreatePostInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            var user = await this.userManager.GetUserAsync(this.User);

            input.UserId = user.Id;

            await this.postsService.CreateAsync(input);

            return this.Redirect("/{categoryName}");
        }
    }
}
