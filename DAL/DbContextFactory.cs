using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using System.Runtime.Remoting.Messaging;

namespace DAL
{
    class DbContextFactory
    {
        public static yichuEntities CreateDbContext()
        {
            yichuEntities dbContext = (yichuEntities)CallContext.GetData("dbContext");
            if (dbContext == null)
            {
                dbContext = new yichuEntities();
                CallContext.SetData("dbContext", dbContext);
            }
            return dbContext;
        }
    }
}
