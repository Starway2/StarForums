namespace StarForums.Web.Controllers
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using StarForums.Data.Models;
    using StarForums.Services.Data;
    using StarForums.Web.ViewModels.Comments;
    using StarForums.Web.ViewModels.Posts;
    using StarForums.Web.ViewModels.Profile;

    public class ProfileController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IProfileService profileService;
        private readonly IPostsService postsService;
        private readonly ICommentsService commentsService;

        public ProfileController(
            UserManager<ApplicationUser> userManager,
            IProfileService profileService,
            IPostsService postsService,
            ICommentsService commentsService)
        {
            this.userManager = userManager;
            this.profileService = profileService;
            this.postsService = postsService;
            this.commentsService = commentsService;
        }

        public async Task<IActionResult> Index(string u)
        {
            if (this.User.Identity.IsAuthenticated)
            {
                if (u == this.User.Identity.Name)
                {
                    return this.Redirect("/Profile");
                }

                if (string.IsNullOrEmpty(u))
                {
                    u = this.User.Identity.Name;
                }
            }

            if (u == null)
            {
                return this.Redirect("/Login");
            }

            var user = await this.userManager.FindByNameAsync(u);

            if (user == null)
            {
                return this.NotFound();
            }

            var posts = this.postsService.GetByUserId<PostViewModel>(user.Id);
            var comments = this.commentsService.GetByUserId<CommentViewModel>(user.Id);
            var model = this.profileService.GetProfileByUserId<ProfileViewModel>(user.Id);

            model.CommentsCount = comments.Count();
            model.PostsCount = posts.Count();

            return this.View(model);
        }

        [Authorize]
        public IActionResult ChangeAvatar()
        {
            return this.View();
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> ChangeAvatar(IFormFile file)
        {
            var size = file.Length;

            if (file != null)
            {
                if (size > 5000000)
                {
                    return this.BadRequest();
                }

                using var stream = new MemoryStream();
                await file.CopyToAsync(stream);

                var fileName = $"{Guid.NewGuid()}_{file.FileName}_{this.User.Identity.Name}";

                var upload = await this.profileService.ChangeAvatar(fileName, stream, this.userManager.GetUserId(this.User));

                if (upload == false)
                {
                    return this.BadRequest();
                }

                return this.RedirectToAction("Index");
            }

            return this.NotFound();
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> ChangeSignature(string signature)
        {
            await this.profileService.ChangeSignature(signature, this.userManager.GetUserId(this.User));

            return this.RedirectToAction("Index");
        }
    }
}
