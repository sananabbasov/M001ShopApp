using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IProductCategoryManager
    {
        void AddProductCategory(ProductCategory productCategory);
        List<ProductCategory> GetProductCategoriesById(int productId);
        void RemoveProductCategories(int productId);
    }
}
