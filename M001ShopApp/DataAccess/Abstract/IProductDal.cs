using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IProductDal : IEntityRepository<Product>
    {
        List<Product> GetByCategory(int categoryId);
        List<Product> GetAllHomeProducts();
        List<Product> RelatedProducts(List<int> categoriesId, int productId);
        Product AddProduct(Product product);
        ProductDetailDTO GetProductById(int productId);
    }
}
