namespace StarForums.Web.Areas.Administration.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using StarForums.Common;

    [Area("Administration")]
    public class AdministrationController : Controller
    {
        [Authorize]
        public IActionResult Index()
        {
            if (!this.User.IsInRole(GlobalConstants.AdministratorRoleName))
            {
                return this.StatusCode(403);
            }

            return this.View();
        }
    }
}
