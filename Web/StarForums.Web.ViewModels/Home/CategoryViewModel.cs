namespace StarForums.Web.ViewModels.Home
{
    using StarForums.Data.Models;
    using StarForums.Services.Mapping;

    public class CategoryViewModel : IMapFrom<Category>
    {
        public string Name { get; set; }

        public string Description { get; set; }
    }
}
