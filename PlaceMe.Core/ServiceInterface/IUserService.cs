using PlaceMe.Infrastructure.Entities;
using System;

namespace PlaceMe.Core.ServiceInterface
{
    public interface IUserService
    {
        String Authenticate(string email, string password);
        User GetMetaData(string email);
        void SignUp(User userDto);
    }
}
