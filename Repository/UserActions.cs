using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Models;

namespace api.Repository
{
    public class UserActions : IUser
    {
        private DataContext _DataContext;
        public UserActions(DataContext dataContext) => _DataContext = dataContext;

        public UserModel addUser(UserModel user)
        {
            try
            {
                _DataContext.User.AddAsync(user);
                _DataContext.SaveChanges();
                return user;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }

        public UserModel deleteUser(int id)
        {
            try
            {
                UserModel _user = _DataContext.User.Find(id);
                _DataContext.User.Remove(_user);
                _DataContext.SaveChanges();
                return _user;
            }
            catch (DbException ex)
            {
                Console.WriteLine(ex);
                return null;
            }

        }

        public Boolean userExists(UserModel user)
        {
            try
            {
                List<UserModel> _user = _DataContext.User.Where(s => s.Email == user.Email && s.Password == user.Password).ToList();
                if (_user.Any())
                {
                    return true;
                }
                return false;
            }
            catch (DbException ex)
            {
                Console.Write(ex.Message);
            }
            return false;
        }
        public UserModel updateUser(int id, UserModel user)
        {
            try
            {
                var _user = _DataContext.User.FirstOrDefault(s => s.Id == id);
                _user.Email = user.Email;
                _user.Password = user.Password;
                _DataContext.SaveChanges();
                return user; 
            }
            catch (DbException ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
    }
}