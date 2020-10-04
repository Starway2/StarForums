namespace StarForums.Web.Controllers
{

    using Microsoft.AspNetCore.Mvc;
    using StarForums.Services.Data;
    using StarForums.Web.ViewModels.Posts;

    public class PostController : Controller
    {
        private readonly IPostsService postsService;

        public PostController(IPostsService postsService)
        {
            this.postsService = postsService;
        }

        [Route("/{categoryName}/{postId}")]
        public IActionResult Index(int postId)
        {
            var post = this.postsService.GetById<PostViewModel>(postId);

            return this.View(post);
        }
    }
}
