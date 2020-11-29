namespace StarForums.Web.Controllers
{
    using System.Threading.Tasks;

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
            var model = this.infoService.GetById<UserInfoViewModel>(user.Id);

            return this.View(model);
        }
    }
}
