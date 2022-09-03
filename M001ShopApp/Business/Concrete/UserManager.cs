using Business.Abstract;
using Core.Entities.Models;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class UserManager : IUserManager
    {
        private readonly IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public void Add(User user)
        {
            _userDal.Add(user);
        }

        public User GetByEmail(string email)
        {
            return _userDal.Get(x => x.Email == email);
        }
    }
}
