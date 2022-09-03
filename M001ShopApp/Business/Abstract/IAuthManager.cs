using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IAuthManager
    {
        public string Login(LoginDTO loginDTO); // Duzelis olunmalidi
        public void Register(RegisterDTO registerDTO);
    }
}
