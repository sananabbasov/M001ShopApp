using Business.Abstract;
using Core.Entities.Models;
using Core.Security.Hashing;
using Core.Security.Jwt;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class AuthManager : IAuthManager
    {
        private readonly IUserManager _userManager;

        public AuthManager(IUserManager userManager)
        {
            _userManager = userManager;
        }

        public string Login(LoginDTO loginDTO)
        {
            var checkUser = _userManager.GetByEmail(loginDTO.Email);
            if (checkUser == null)
                return null;
            var checkPassword = HashingHelper.VerifyPassword(loginDTO.Password, checkUser.PasswordHash, checkUser.PasswordSalt);
            if (!checkPassword)
                return null;

            var token = TokenGenerator.Token(checkUser,"User");
            return token;
        }

        public void Register(RegisterDTO registerDTO)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.HashPassword(registerDTO.Password, out passwordHash, out passwordSalt);
            User user = new()
            {
                Email = registerDTO.Email,
                Name = registerDTO.Name,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Surname = registerDTO.Surname,
            };
            _userManager.Add(user);
        }
    }
}
