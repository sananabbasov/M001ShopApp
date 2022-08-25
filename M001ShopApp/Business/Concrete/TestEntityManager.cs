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
    public class TestEntityManager : ITestEntityManager
    {
        private readonly ITestEntityDal _testEntityDal;

        public TestEntityManager(ITestEntityDal testEntityDal)
        {
            _testEntityDal = testEntityDal;
        }

        public void Add(TestEntity testEntity)
        {
            _testEntityDal.Add(testEntity);
        }

        public TestEntity Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<TestEntity> GetAll()
        {
            return _testEntityDal.GetAll();
        }

        public void Remove(TestEntity testEntity)
        {
            throw new NotImplementedException();
        }

        public void Update(TestEntity testEntity)
        {
            throw new NotImplementedException();
        }
    }
}
