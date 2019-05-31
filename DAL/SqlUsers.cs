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

        //public void Register(Users users)
        //{
        //    db.Users.Add(users);
        //    db.SaveChanges();
        //}
        //public Users Login(int Userid, string password)
        //{
        //    var users = db.Users.Where(u => u.UserID == Userid)
        //        .Where(u => u.Password == password).FirstOrDefault();
        //    return users;
        //}
        public bool Login(int? UserID, string PasswordL)
        {            
            //var users = db.Users.Where(x => x.UserID == UserID && x.Password == PasswordL).FirstOrDefault();
            //var users = db.Users.Where(x => x.UserID == UserID && x.Password == PasswordL).FirstOrDefault();
            var users = db.Users.Where(x => x.UserID == UserID)
                .Where(x => x.Password == PasswordL).FirstOrDefault();
            if (users != null)
            {
                return true;
            }
            else
                return false;

        }



        public bool Register(string TrueName, string PasswordR, string Tel)
        {
            
                if (db.Users.Any(x => x.Tel == Tel))
                {
                    return false;
                }
                else
                {
                var users = new Users()
                {
                    UserName = TrueName,

                    Password = PasswordR,
                    Tel = Tel
                    };
                    db.Users.Add(users);
                    db.SaveChanges();
                    return true;
                }
            
        }
        //string IUsers.FindPassword(string Email, string TrueName)
        public string FindPassword(string Tel, string TrueName)
        {
            //using (yichuEntities db = new yichuEntities())
            //{
            //    var passwords = db.Users.Where(m => m.Email == Email && m.UserName == TrueName).FirstOrDefault();
            //    if (passwords != null)
            //    {
            //        var password = passwords.Password;
            //        return password;
            //    }
            //    else
            //    {
            //        string message = "提交信息有误，找回密码失败！";
            //        return message;
            //    }
            //}
            var passwords = db.Users.Where(m => m.Tel == Tel && m.UserName == TrueName).FirstOrDefault();
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

        public Users GetUserById(int userid)
        {
            return db.Users.Where(u => u.UserID == userid).FirstOrDefault();
        }
    }
}
