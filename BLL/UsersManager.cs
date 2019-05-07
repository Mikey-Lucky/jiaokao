using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DALFactory;
using IDAL;
using Models;

namespace BLL
{
    class UsersManager
    {
        IUsers iusers = DataAccess.CreateUser();
        public void Register(Users users)
        {
            iusers.Register(users);
        }
        public Users Login(int Userid,string password)
        {
            var users = iusers.Login(Userid,password);
            return users;
        }
    }
}
