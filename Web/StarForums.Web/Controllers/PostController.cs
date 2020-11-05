namespace StarForums.Web.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using StarForums.Data.Models;
    using StarForums.Services.Data;
    using StarForums.Web.ViewModels.Comments;
    using StarForums.Web.ViewModels.Home;
    using StarForums.Web.ViewModels.Posts;

    public class PostController : BaseController
    {
        private readonly IPostsService postsService;
        private readonly ICategoriesService categoriesService;
        private readonly ICommentsService commentsService;
        private readonly UserManager<ApplicationUser> userManager;

        public PostController(IPostsService postsService, ICategoriesService categoriesService, ICommentsService commentsService, UserManager<ApplicationUser> userManager)
        {
            this.postsService = postsService;
            this.categoriesService = categoriesService;
            this.commentsService = commentsService;
            this.userManager = userManager;
        }

        [Route("/{categoryName}/{postId}")]
        public IActionResult Index(int postId, string categoryName)
        {
            var post = this.postsService.GetById<PostViewModel>(postId);

            if (post == null)
            {
                return this.Redirect("/" + categoryName);
            }

            var comments = this.commentsService.GetAll<CommentViewModel>(postId);

            post.Comments = comments;

            return this.View(post);
        }

        [Route("/{categoryName}/Create")]
        [Authorize]
        public IActionResult Create(string categoryName)
        {
            if (!this.User.Identity.IsAuthenticated)
            {
                return this.Redirect("/Login");
            }

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
            if (!this.User.Identity.IsAuthenticated)
            {
                return this.Redirect("/Login");
            }

            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            var user = await this.userManager.GetUserAsync(this.User);

            input.UserId = user.Id;

            await this.postsService.CreateAsync(input);

            return this.Redirect("/{categoryName}");
        }

        [Route("/{categoryName}/{postId}/Delete")]
        [Authorize]
        public async Task<IActionResult> Delete(int postId, string categoryName)
        {
            var post = this.postsService.GetById<PostViewModel>(postId);

            if (this.userManager.GetUserId(this.User) == post.User.Id || this.User.IsInRole("Administrator"))
            {
                await this.postsService.Delete(postId);

                return this.Redirect("/" + categoryName);
            }

            return this.NotFound();
        }

        [Route("/{categoryName}/{postId}/AddComment")]
        [Authorize]
        public IActionResult AddComment(int postId)
        {
            var model = new CommentInputModel() { PostId = postId };
            return this.View(model);
        }

        [Route("/{categoryName}/{postId}/AddComment")]
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddComment(CommentInputModel model, int postId, string categoryName)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            var user = await this.userManager.GetUserAsync(this.User);

            model.UserId = user.Id;

            await this.commentsService.AddComment(model);

            return this.Redirect($"/{categoryName}/{postId}");
        }
    }
}
