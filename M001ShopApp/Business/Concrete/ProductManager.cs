using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ProductManager : IProductManager
    {
        private readonly IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public Product Add(Product product)
        {
            return _productDal.AddProduct(product);
        }

        public void Delete(int productId)
        {
            var product = _productDal.Get(x=>x.Id == productId);
            product.IsDelete = true;
            _productDal.Update(product);
        }

        public Product Get(int id)
        {
            return _productDal.Get(x => x.Id == id);
        }

        public List<Product> GetAll()
        {
            return _productDal.GetAll();
        }

        public List<Product> GetHomeProducts()
        {
            return _productDal.GetAllHomeProducts();
        }

        public ProductDetailDTO GetProductById(int id)
        {
            return _productDal.GetProductById(id);
        }

        public List<Product> GetProductsByCategory(int categoryId)
        {
            return _productDal.GetByCategory(categoryId);
        }

        public List<Product> GetSliderProducts()
        {
            return _productDal.GetAll(x=>x.IsSlider == true && x.IsDelete == false);
        }

        public List<Product> RelatedProducts(List<int> categoriesId, int productId)
        {
            return _productDal.RelatedProducts(categoriesId, productId);
        }

        public void Update(Product product)
        {
            _productDal.Update(product);
        }
    }
}
