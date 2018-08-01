using System;
using System.Configuration;
using YAMBOLY.GESTIONRUTAS.HELPER;

namespace YAMBOLY.GESTIONRUTAS.DATAAACCESS.Queries
{
    public class Queries
    {
        public static string GetStringContent(EmbebbedFileName embebbedFileName)
        {
            var query = string.Empty;
            var fileString = XMLHelper.GetXMLString(System.Reflection.Assembly.GetExecutingAssembly(), embebbedFileName);
            var values = fileString.Split(new string[] { ConstantHelper.BEGINQUERY }, StringSplitOptions.None);
            if (values.Length > 1)
                query = values[1];
            return query;
        }

        public static string GetUrlPath()
        {
            var ip = ConfigurationManager.AppSettings[ConstantHelper.XSJSPATH_KEY];
            return ip;
        }
    }
}
