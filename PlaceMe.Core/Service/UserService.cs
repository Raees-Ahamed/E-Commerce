using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using PlaceMe.Core.Helpers;
using PlaceMe.Core.ServiceInterface;
using PlaceMe.Infrastructure.Entities;
using PlaceMe.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace PlaceMe.Core.Service
{

    public class UserService : IUserService
    {
        // users hardcoded for simplicity, store in a db with hashed passwords in production applications
        private readonly AppSettings _appSettings;
        private readonly IUnitOfWork unitOfWork;

        public UserService(IOptions<AppSettings> appSettings, IUnitOfWork unitOfWork)
        {
            _appSettings = appSettings.Value;
            this.unitOfWork = unitOfWork;
        }

        public IEnumerable<User> _getUser()
        {
            return unitOfWork.UserRepository.Get(includeProperties: "AddressLines").ToList();
        }

        public string Authenticate(string email, string password)
        {
            var user = _getUser().SingleOrDefault(x => x.Email == email && x.Password == password);

            // return null if user not found
            if (user == null)
                return null;

            // authentication successful so generate jwt token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Email,user.Email.ToString()),
                    new Claim(ClaimTypes.Role, user.Role.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            user.Token = tokenHandler.WriteToken(token);

            return "Bearer " + user.Token;
        }

        public void SignUp(User user)
        {
            try
            {
                unitOfWork.UserRepository.Create(user);
                unitOfWork.Save();
                unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                unitOfWork.Rollback();
                throw ex;
            }
        }

        public User GetMetaData(string email)
        {
            try
            {
                return unitOfWork.UserRepository.Get(includeProperties: "AddressLines").First(u => u.Email == email);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
