namespace StarForums.Web.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using StarForums.Data.Models;
    using StarForums.Services.Data;
    using StarForums.Web.ViewModels.Comments;
    using StarForums.Web.ViewModels.Posts;
    using StarForums.Web.ViewModels.Profile;

    public class ProfileController : BaseController
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IProfileService service;
        private readonly IPostsService postsService;
        private readonly ICommentsService commentsService;

        public ProfileController(UserManager<ApplicationUser> userManager, IProfileService profileService, IPostsService postsService, ICommentsService commentsService)
        {
            this.userManager = userManager;
            this.service = profileService;
            this.postsService = postsService;
            this.commentsService = commentsService;
        }

        public async Task<IActionResult> Index(string u)
        {
            var user = await this.userManager.FindByNameAsync(u);
            var posts = this.postsService.GetByUserId<PostViewModel>(user.Id);
            var comments = this.commentsService.GetByUserId<CommentViewModel>(user.Id);
            var model = this.service.GetProfileByUserId<ProfileViewModel>(user.Id);

            model.CommentsCount = comments.Count();
            model.PostsCount = posts.Count();

            return this.View(model);
            }
    }
}
