namespace StarForums.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using StarForums.Services.Data;
    using StarForums.Web.ViewModels.Home;

    public class CategoryController : Controller
    {
        private readonly ICategoriesService categoriesService;

        public CategoryController(ICategoriesService categoriesService)
        {
            this.categoriesService = categoriesService;
        }

        [Route("/{categoryName}")]
        public IActionResult Index(string categoryName)
        {
            var category = this.categoriesService.GetByName(categoryName);

            if (category == null)
            {
                // TODO: Make 404 page.
                return this.Redirect("/");
            }

            var viewmodel = new CategoryViewModel() { Name = category.Name, Description = category.Description };

            return this.View(viewmodel);
        }
    }
}
