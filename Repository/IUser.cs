using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;

namespace api.Repository
{
    public interface IUser
    {
        UserModel addUser (UserModel user);
        Boolean userExists(UserModel user);
        UserModel updateUser(int id, UserModel user);
        UserModel deleteUser(int id);
    }
}