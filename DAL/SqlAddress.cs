using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IDAL;
using Models;


namespace DAL
{
    public class SqlAddress:IAddress
    {
        yichuEntities db = DbContextFactory.CreateDbContext();
        public void Add(int userid,string address)
        {
            var add = db.Address.Where(u => u.UserID == userid && u.Address1 == address).FirstOrDefault();
            db.Address.Add(add);
            db.SaveChanges();
        }
    }
}
