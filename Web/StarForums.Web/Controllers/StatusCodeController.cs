namespace StarForums.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class StatusCodeController : Controller
    {
        [Route("/Error/Index/{statusCode}")]
        public IActionResult Index(int statusCode)
        {
            switch (statusCode)
            {
                case 404:
                    return this.View("NotFound");
                case 403:
                    return this.View("Forbidden");
                default:
                    return this.View("NotFound");
            }
        }
    }
}
