namespace StarForums.Web.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using StarForums.Common;
    using StarForums.Data.Models;
    using StarForums.Services.Data;
    using StarForums.Web.ViewModels.Comments;
    using StarForums.Web.ViewModels.Home;
    using StarForums.Web.ViewModels.Posts;

    public class PostController : Controller
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

        public IActionResult Index(int id)
        {
            var post = this.postsService.GetById<PostViewModel>(id);

            if (post == null)
            {
                return this.NotFound();
            }

            var comments = this.commentsService.GetAll<CommentViewModel>(id);

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
        public async Task<IActionResult> Create(CreatePostInputModel input, string categoryName)
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

            var postId = await this.postsService.CreateAsync(input);

            return this.Redirect($"/{categoryName}/{postId}");
        }

        [Route("/{categoryName}/{postId}/Delete")]
        [Authorize]
        public async Task<IActionResult> Delete(int postId, string categoryName)
        {
            var post = this.postsService.GetById<PostViewModel>(postId);

            if (this.userManager.GetUserId(this.User) == post.User.Id || this.User.IsInRole(GlobalConstants.AdministratorRoleName) || this.User.IsInRole(GlobalConstants.ModeratorRoleName))
            {
                await this.postsService.DeleteAsync(postId);

                return this.Redirect("/" + categoryName);
            }

            return this.Redirect($"/{categoryName}/{postId}");
        }

        [Route("/{categoryName}/{postId}/AddComment")]
        [Authorize]
        public IActionResult AddComment(int postId)
        {
            var post = this.postsService.GetById<PostViewModel>(postId);

            if (post.Id != postId)
            {
                return this.NotFound();
            }

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

            await this.commentsService.AddCommentAsync(model);

            return this.Redirect($"/{categoryName}/{postId}");
        }

        [Route("/{categoryName}/{postId}/Edit")]
        [Authorize]
        public IActionResult Edit(int postId)
        {

            var post = this.postsService.GetById<PostEditViewModel>(postId);
            var currentUserId = this.userManager.GetUserId(this.User);

            post.ReturnUrl = this.HttpContext.Request.Headers["Referer"].ToString();

            if (post.UserId == currentUserId || this.User.IsInRole(GlobalConstants.AdministratorRoleName) || this.User.IsInRole(GlobalConstants.ModeratorRoleName))
            {
                return this.View(post);
            }

            return this.NotFound();
        }

        [Route("/{categoryName}/{postId}/Edit")]
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Edit(PostEditViewModel model, string categoryName)
        {
            if (!this.ModelState.IsValid)
            {
                this.View(model);
            }

            await this.postsService.EditAsync(model.Id, model.Title, model.Content);

            return this.Redirect($"/{categoryName}/{model.Id}");
        }

        [Authorize]
        public IActionResult EditComment(string categoryName, int postId, int commentId)
        {
            var model = this.commentsService.GetById<EditCommentInputModel>(commentId);

            return this.View(model);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> EditComment(EditCommentInputModel model, string categoryName, int postId)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            await this.commentsService.EditCommentAsync(model.Id, model.Content);

            // TODO: Redirect to comment
            return this.Redirect($"/{model.Post.Category.Name}/{model.PostId}");
        }
    }
}
