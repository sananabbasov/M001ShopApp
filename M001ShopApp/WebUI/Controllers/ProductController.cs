using Business.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebUI.ViewModels;

namespace WebUI.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductManager _productManager;

        public ProductController(IProductManager productManager)
        {
            _productManager = productManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Authorize]
        public IActionResult Detail(int id)
        {
            try
            {
                var product = _productManager.GetProductById(id);
                var productCategories = product.Categories.Select(x => x.Id).ToList();
                var relatedProducts = _productManager.RelatedProducts(productCategories, product.Id);
                ProductDetailVM productDetail = new()
                {
                    Product = product,
                    Products = relatedProducts
                };
                return View(productDetail);
            }
            catch (Exception)
            {

                return NotFound();
            }

        }
    }
}
