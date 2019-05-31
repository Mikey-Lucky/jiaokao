using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using IDAL;

namespace DAL
{
    public class SqlU_Attention_U:IU_Attention_U
    {
        //userid1为关注者 userid2为被关注者
        yichuEntities db = DbContextFactory.CreateDbContext();
        public void addattention(U_Attention_U attention)
        {
            db.U_Attention_U.Add(attention);
            db.SaveChanges();
        }
        public bool deleteattention(int id)
        {
            U_Attention_U attention = db.U_Attention_U.Where(b => b.U_Attention_UID == id).FirstOrDefault();
            if (attention != null)
            {
                db.U_Attention_U.Remove(attention);
                db.SaveChanges();
                return true;
            }
            else return false;
        }
        public IQueryable<U_Attention_U> attention(int userid)
        {
            return db.U_Attention_U.Where(f => f.User1ID == userid);
        }
        public IQueryable<U_Attention_U> fens(int userid)
        {
            return db.U_Attention_U.Where(f => f.User2ID == userid);
        }

        public int fensnum(int userid)
        {
            int num = db.U_Attention_U.Where(v => v.User2ID == userid).Count();
            return num;
        }

        public int attentionnum(int userid)
        {
            int num = db.U_Attention_U.Where(v => v.User1ID == userid).Count();
            return num;
        }
    }
}
