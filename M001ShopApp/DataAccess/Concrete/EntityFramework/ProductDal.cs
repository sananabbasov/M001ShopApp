using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class ProductDal : EfEntityRepositoryBase<Product, AppDbContext>, IProductDal
    {
        public Product AddProduct(Product product)
        {
            using AppDbContext _context = new();

            _context.Products.Add(product);
            _context.SaveChanges();

            return product;

        }

        public List<Product> GetAllHomeProducts()
        {
            using AppDbContext _contex = new();
            return _contex.Products.Where(x=>x.IsDelete == false).Take(3).ToList();
        }

        public List<Product> GetByCategory(int categoryId)
        {
            using AppDbContext _context = new();

            var productCategories = _context.ProductCategories.Where(c => c.CategoryId == categoryId).ToList();
            List<Product> products = new();

            foreach (var pC in productCategories)
            {
                var findedProduct = _context.Products.FirstOrDefault(x=>x.Id == pC.ProductId);
                products.Add(findedProduct);
            }
            return products;
        }

        public ProductDetailDTO GetProductById(int productId)
        {
            using AppDbContext _context = new();

            var productCategory = _context.ProductCategories.Include(x=>x.Category).Where(p => p.ProductId == productId).ToList();
            var product = _context.Products.FirstOrDefault(x=>x.Id == productId);
            List<Category> categoryList = new();

            foreach (var item in productCategory)
            {
                categoryList.Add(item.Category);
            }
            ProductDetailDTO result = new()
            {
                Id = product.Id,
                Name = product.Name,
                CoverPhoto = product.CoverPhoto,
                Description = product.Description,
                Discound = product.Discound,
                PhotoUrl = product.PhotoUrl,
                Price = product.Price,
                Quantity = product.Quantity,
                Categories = categoryList
            };
            return result;
        }

        public List<Product> RelatedProducts(List<int> categoriesId, int productId)
        {
            using var _context = new AppDbContext();
            var productCategories = _context.ProductCategories.Where(x=>x.CategoryId == categoriesId[0]).Include(x=>x.Product);
            List<Product> products = new();
            for (int i = 0; i < productCategories.ToList().Count; i++)
            {
                products.Add(productCategories.Skip(i).FirstOrDefault().Product);
            }
            return products.Where(x => x.Id != productId).Take(3).ToList();
        }
    }
}
