namespace StarForums.Web.Controllers
{
    using CloudinaryDotNet.Actions;
    using Microsoft.AspNetCore.Mvc;

    public class StatusCode : Controller
    {
        [Route("/Error/Index/{statusCode}")]
        public IActionResult Index(int statusCode)
        {
            switch (statusCode)
            {
                case 404:
                    return this.View();
                default:
                    break;
            }

            return this.View();
        }
    }
}
