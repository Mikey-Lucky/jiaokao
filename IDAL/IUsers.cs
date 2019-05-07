using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace IDAL
{
    public interface IUsers
    {
        //void Register(Users users);
        //Users Login(int UserID, string Password);
        //string FindPassword(string Email, string TrueName);

        bool Login(int? UserID, string PasswordL);
        bool Register(string TrueName, string PasswordR, string Tel);
        string FindPassword(string Tel,string TrueName);

    }
}
