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
    public class AddressManager
    {
        //IAddress iaddress = new DataAccess.CreateAddress();
        IAddress iaddress = DataAccess.CreateAddress();
        public void Add(int userid, string address)
        {
            iaddress.Add(userid,address);
        }
    }
}
