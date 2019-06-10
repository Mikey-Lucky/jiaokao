using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Reflection;
using IDAL;
using Models;

namespace DALFactory
{
    public class DataAccess
    {
        private static string AssemblyName = ConfigurationManager.AppSettings["Path"].ToString();
        private static string db = ConfigurationManager.AppSettings["DB"].ToString();
        public static IUsers CreateUsers()
        {
            string className = AssemblyName + "." + db + "Users";
            return (IUsers)Assembly.Load(AssemblyName).CreateInstance(className);
        }
        public static INote CreateNote()
        {
            string className = AssemblyName + "." + db + "Note";
            return (INote)Assembly.Load(AssemblyName).CreateInstance(className);
        }
        public static IVideo CreateVideo()
        {
            string className = AssemblyName + "." + db + "Video";
            return (IVideo)Assembly.Load(AssemblyName).CreateInstance(className);
        }
        public static IGoods CreateGoods()
        {
            string className = AssemblyName + "." + db + "Goods";
            return (IGoods)Assembly.Load(AssemblyName).CreateInstance(className);
        }
        public static IShirt CreateShirt()
        {
            string className = AssemblyName + "." + db + "Shirt";
            return (IShirt)Assembly.Load(AssemblyName).CreateInstance(className);
        }
        public static ICoat CreateCoat()
        {
            string className = AssemblyName + "." + db + "Coat";
            return (ICoat)Assembly.Load(AssemblyName).CreateInstance(className);
        }
        public static ISuit CreateSuit()
        {
            string className = AssemblyName + "." + db + "Suit";
            return (ISuit)Assembly.Load(AssemblyName).CreateInstance(className);
        }
        public static INetherGarment CreateNetherGarment()
        {
            string className = AssemblyName + "." + db + "NetherGarment";
            return (INetherGarment)Assembly.Load(AssemblyName).CreateInstance(className);
        }

        public static IGGCC CreateGGCC()
        {
            string className = AssemblyName + "." + db + "GGCC";
            return (IGGCC)Assembly.Load(AssemblyName).CreateInstance(className);
        }
        public static ICart CreateCart1()
        {
            string className = AssemblyName + "." + db + "Cart";
            return (ICart)Assembly.Load(AssemblyName).CreateInstance(className);
        }
        public static IOrders CreateOrders()
        {
            string className = AssemblyName + "." + db + "Orders";
            return (IOrders)Assembly.Load(AssemblyName).CreateInstance(className);
        }
        public static IAddress CreateAddress()
        {
            string className = AssemblyName + "." + db + "Address";
            return (IAddress)Assembly.Load(AssemblyName).CreateInstance(className);
        }
        public static IVideoLike CreateVideoLike()
        {
            string className = AssemblyName + "." + db + "VideoLike";
            return (IVideoLike)Assembly.Load(AssemblyName).CreateInstance(className);
        }
        public static IVideoSelect CreateVideoSelect()
        {
            string className = AssemblyName + "." + db + "VideoSelect";
            return (IVideoSelect)Assembly.Load(AssemblyName).CreateInstance(className);
        }
        public static IOrderDetails CreateOrderDetails()
        {
            string className = AssemblyName + "." + db + "OrderDetails";
            return (IOrderDetails)Assembly.Load(AssemblyName).CreateInstance(className);
        }
        //public static IGoodsLike CreateGoodsLike()
        //{
        //    string className = AssemblyName + "." + db + "GoodsLike";
        //    return (IGoodsLike)Assembly.Load(AssemblyName).CreateInstance(className);
        //}
        public static IGoodsLike CreateGoodsLike()
        {
            string className = AssemblyName + "." + db + "GoodsLike";
            return (IGoodsLike)Assembly.Load(AssemblyName).CreateInstance(className);
        }
        public static INoteLike CreateNoteLike()
        {
            string className = AssemblyName + "." + db + "NoteLike";
            return (INoteLike)Assembly.Load(AssemblyName).CreateInstance(className);
        }
        public static IVideoComment CreateVideoComment()
        {
            string className = AssemblyName + "." + db + "VideoComment";
            return (IVideoComment)Assembly.Load(AssemblyName).CreateInstance(className);
        }
        public static IU_Reply_VideoComment CreateU_Reply_VideoComment()
        {
            string className = AssemblyName + "." + db + "U_Reply_VideoComment";
            return (IU_Reply_VideoComment)Assembly.Load(AssemblyName).CreateInstance(className);
        }
        public static IGoodsComment CreateGoodsComment()
        {
            string className = AssemblyName + "." + db + "GoodsComment";
            return (IGoodsComment)Assembly.Load(AssemblyName).CreateInstance(className);
        }
        public static IComReply CreateComReply()
        {
            string className = AssemblyName + "." + db + "ComReply";
            return (IComReply)Assembly.Load(AssemblyName).CreateInstance(className);
        }
        public static IU_Attention_U CreateU_Attention_U()
        {
            string className = AssemblyName + "." + db + "U_Attention_U";
            return (IU_Attention_U)Assembly.Load(AssemblyName).CreateInstance(className);
        }
        public static INoteComment CreateNoteComment()
        {
            string className = AssemblyName + "." + db + "NoteComment";
            return (INoteComment)Assembly.Load(AssemblyName).CreateInstance(className);
        }
    }
}
