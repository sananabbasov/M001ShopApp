using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess.Mongo
{
    public class MongoRepositoryBase<TDocument> : IEntityRepository<TDocument>
        where TDocument : class, IEntity, new()
    {
        public void Add(TDocument entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(TDocument entity)
        {
            throw new NotImplementedException();
        }

        public TDocument Get(Expression<Func<TDocument, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<TDocument> GetAll(Expression<Func<TDocument, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public void Update(TDocument entity)
        {
            throw new NotImplementedException();
        }
    }
}
