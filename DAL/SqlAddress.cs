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
            var p = db.Address.Where(u => u.Address1 == address).FirstOrDefault();
            if (p == null)
            {
                var add = new Address()
                {
                    UserID = userid,
                    Address1 = address,
                };
                db.Address.Add(add);
                db.SaveChanges();
            }
            
            
        }
    }
}
