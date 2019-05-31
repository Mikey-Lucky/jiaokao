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
    public class UsersManager
    {
        IUsers iusers = DataAccess.CreateUsers();
        public bool Register(string truename,string password,string tel)
        {
            iusers.Register(truename,password,tel);
            return true;
        }
        public bool Login(int? Userid,string password)
        {
            iusers.Login(Userid,password);
            //return users;
            return true;
        }
        public string FindPassword(string Tel, string TrueName)
        {
            var fwsd = iusers.FindPassword(Tel,TrueName);
            return fwsd;
        }
        //通过用户id找到用户信息
        public Users GetUserById(int userid)
        {
            return iusers.GetUserById(userid);
        }
    }
}
