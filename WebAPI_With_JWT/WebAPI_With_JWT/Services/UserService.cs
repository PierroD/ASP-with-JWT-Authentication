using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI_With_JWT.HttpMessages.Requests;
using WebAPI_With_JWT.HttpMessages.Responses;
using WebAPI_With_JWT.Models;
using WebAPI_With_JWT.Services.Interfaces;
using WebAPI_With_JWT.Utils.Helpers;
using WebAPI_With_JWT.Utils.Settings;

namespace WebAPI_With_JWT.Services
{
    public class UserService : IUserService
    {
        private List<User> _users;
        private readonly AppSettings _appSettings;

        public UserService(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
            _users = new List<User> // static list for the test, but you should do it differently
            {
                new User { Id= 1, Username="test", Email="test@test.com", Password="test123"},
                new User { Id= 2, Username="test2", Email="test2@test.com", Password="test123"},
            };

        }

        public LoginResponse Login(LoginRequest model)
        {
            var user = _users.SingleOrDefault(x => (x.Username == model.UsernameOrEmail || x.Email == model.UsernameOrEmail) && x.Password == model.Password);

            // return null if user not found
            if (user == null) return null;

            // authentication successful so generate jwt token
            var token = TokenHelper.generateJwtToken(user, _appSettings.Secret);

            return new LoginResponse(user, token);
        }

        public User Register(User user)
        {
            if (!UserExist(user))
            {
                user.Id = _users.LastOrDefault().Id + 1;
                _users.Add(user);
                
                return user;
            }
            return null;
        }

        public User Update(User user)
        {
            if (UserExist(user))
            {
                User updatedUser = _users.FirstOrDefault(x => x.Id == user.Id);
                updatedUser = user;
                return updatedUser;
            }
            return null;
        }

        public void Delete(int id)
        {
            User deletedUser = _users.FirstOrDefault(x => x.Id == id);
            _users.Remove(deletedUser);
        }

        public IEnumerable<User> GetAll()
        {
            return _users;
        }

        public User GetById(int id)
        {
            return _users.FirstOrDefault(x => x.Id == id);
        }

        public User GetByMail(string mail)
        {
            foreach (var user in _users)
            {
                if (user.Email.Equals(mail))
                    return user;
            }
            return null;
        }

        private bool UserExist(User user)
        {
            foreach (var u in _users)
            {
                if (u.Username == user.Email || u.Email == user.Email || u.Id == user.Id)
                    return true;
            }
            return false;
        }

    }
}
