using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI_With_JWT.HttpMessages.Requests;
using WebAPI_With_JWT.HttpMessages.Responses;
using WebAPI_With_JWT.Models;

namespace WebAPI_With_JWT.Services.Interfaces
{
    public interface IUserService
    {
        LoginResponse Login(LoginRequest model);
        User Register(User user);
        User Update(User user);
        void Delete(int id);
        IEnumerable<User> GetAll();
        User GetById(int id);
        User GetByMail(string mail);
    }
}
