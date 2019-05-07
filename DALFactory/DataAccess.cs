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
        public static IUsers CreateUser()
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
    }
}
