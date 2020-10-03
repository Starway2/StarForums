namespace StarForums.Web.ViewModels.Home
{
    using System.Collections.Generic;

    public class CategoryListModel
    {
        public ICollection<CategoryViewModel> Categories { get; set; }
    }
}
