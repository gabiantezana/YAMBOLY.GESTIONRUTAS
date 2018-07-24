using System.Configuration;
using YAMBOLY.GESTIONRUTAS.HELPER;

namespace YAMBOLY.GESTIONRUTAS.DATAAACCESS.Queries
{
    public class Queries
    {
        public static string GetStringContent(EmbebbedFileName embebbedFileName)
        {
            var query = XMLHelper.GetXMLString(System.Reflection.Assembly.GetExecutingAssembly(), embebbedFileName);
            query = query .Substring((query.IndexOf("--BEGINQUERY") + 12) , (query.Length.ToInteger() - query.IndexOf("BEGINQUERY").ToInteger() -10)).Trim();//TODO:
            return query;
        }

        public static string GetUrlPath()
        {
            var ip = ConfigurationManager.AppSettings["XSJSPath"];
            return ip;
        }
    }
}
