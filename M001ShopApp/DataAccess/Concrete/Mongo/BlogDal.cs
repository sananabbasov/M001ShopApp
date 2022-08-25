using Core.DataAccess.Mongo;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.Mongo
{
    public class BlogDal : MongoRepositoryBase<Blog>, IBlogDal
    {
        public void RemoveAllTable()
        {
            throw new NotImplementedException();
        }
    }
}
