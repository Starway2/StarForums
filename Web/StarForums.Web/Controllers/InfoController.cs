namespace StarForums.Web.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using StarForums.Data.Models;
    using StarForums.Services.Data;
    using StarForums.Web.ViewModels.Info;

    public class InfoController : Controller
    {
        private readonly IUserInfoService infoService;
        private readonly UserManager<ApplicationUser> userManager;

        public InfoController(IUserInfoService infoService, UserManager<ApplicationUser> userManager)
        {
            this.infoService = infoService;
            this.userManager = userManager;
        }

        public async Task<IActionResult> Index(string u)
        {
            var user = await this.userManager.FindByNameAsync(u);

            if (user == null)
            {
                return this.NotFound();
            }

            var model = this.infoService.GetById<UserInfoViewModel>(user.Id);


            return this.View(model);
        }

        [Authorize]
        public async Task<IActionResult> Edit(string u)
        {
            var user = await this.userManager.FindByNameAsync(u);
            var model = this.infoService.GetById<UserInfoInputModel>(user.Id);

            if (this.User.Identity.Name != user.UserName || model.UserId != user.Id)
            {
                return this.NotFound();
            }

            return this.View(model);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Edit(UserInfoInputModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }


            await this.infoService.UpdateInfoAsync(model);

            return this.RedirectToAction("Index", new { u = model.UserUsername });
        }
    }
}
