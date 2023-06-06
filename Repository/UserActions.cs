using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;

namespace api.Repository
{
    public class UserActions: IUser
    {
        private DataContext _DataContext;
        public UserActions(DataContext dataContext) => _DataContext = dataContext;

    }
}