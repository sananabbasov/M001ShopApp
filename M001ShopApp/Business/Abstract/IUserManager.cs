using Core.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IUserManager
    {
        void Add(User user);
        User GetByEmail(string email);
    }
}
