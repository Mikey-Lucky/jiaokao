using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IDAL;
using Models;
using System.Data.Entity;

namespace DAL
{
    public class SqlUsers:IUsers
    {
        yichuEntities db = DbContextFactory.CreateDbContext();

        public void Register(Users users)
        {
            db.Users.Add(users);
            db.SaveChanges();
        }
        public Users Login(int Userid,string password)
        {
            var users = db.Users.Where(u => u.UserID == Userid)
                .Where(u => u.Password == password).FirstOrDefault();
            return users;
        }
        string IUsers.FindPassword(string Email, string TrueName)
        {
            using (yichuEntities db = new yichuEntities())
            {
                var passwords = db.Users.Where(m => m.Email == Email && m.UserName == TrueName).FirstOrDefault();
                if (passwords != null)
                {
                    var password = passwords.Password;
                    return password;
                }
                else
                {
                    string message = "提交信息有误，找回密码失败！";
                    return message;
                }
            }
        }
    }
}
