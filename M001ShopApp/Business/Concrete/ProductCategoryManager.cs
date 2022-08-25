using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ProductCategoryManager : IProductCategoryManager
    {
        private readonly IProductCategoryDal _productCategoryDal;

        public ProductCategoryManager(IProductCategoryDal productCategoryDal)
        {
            _productCategoryDal = productCategoryDal;
        }

        public void AddProductCategory(ProductCategory productCategory)
        {
            _productCategoryDal.Add(productCategory);
        }


        public List<ProductCategory> GetProductCategoriesById(int productId)
        {
            return _productCategoryDal.GetAll(x => x.ProductId == productId);
        }

        public void RemoveProductCategories(int productId)
        {
            var deletedProductCategory = _productCategoryDal.GetAll(x => x.ProductId == productId);
            for (int i = 0; i < deletedProductCategory.Count; i++)
            {
                _productCategoryDal.Delete(deletedProductCategory[i]);
            }
        }
    }
}
