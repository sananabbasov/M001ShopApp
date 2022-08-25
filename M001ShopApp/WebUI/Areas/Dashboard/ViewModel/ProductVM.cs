using Entities.Concrete;

namespace WebUI.Areas.Dashboard.ViewModel
{
    public class ProductVM
    {
        public Product Product { get; set; }
        public List<int> ProductCategories { get; set; }
        public List<Category> Categories { get; set; }
    }
}
