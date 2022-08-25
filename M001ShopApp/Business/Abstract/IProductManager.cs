using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IProductManager
    {
        Product Add(Product product);
        void Update(Product product);
        void Delete(int productId);
        List<Product> GetHomeProducts();
        List<Product> RelatedProducts(List<int> categoriesId, int productId);
        List<Product> GetAll();
        Product Get(int id);
        ProductDetailDTO GetProductById(int id);
        List<Product> GetProductsByCategory(int categoryId);
        List<Product> GetSliderProducts();
    }
}