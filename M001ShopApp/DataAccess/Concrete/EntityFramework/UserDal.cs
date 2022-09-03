using Core.DataAccess.EntityFramework;
using Core.Entities.Models;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class UserDal : EfEntityRepositoryBase<User,AppDbContext>, IUserDal
    {
    }
}
