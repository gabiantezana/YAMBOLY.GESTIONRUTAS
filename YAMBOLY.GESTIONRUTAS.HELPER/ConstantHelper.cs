using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YAMBOLY.GESTIONRUTAS.HELPER
{
    public class ConstantHelper
    {
        public const String PASSWORD_DEFAULT = "12345";
        public static readonly Int32 DEFAULT_PAGE_SIZE = 10;
        public static readonly byte[] ENCRIPT_KEY = { 45, 12, 45, 78, 2, 45, 12, 65, 87, 12, 45, 32, 20, 58, 15, 36, 47, 85, 96, 20, 24, 23, 65, 24 };
        public static readonly byte[] ENCRIPT_METHOD = { 87, 10, 65, 35, 12, 66, 21, 65 };
        public static readonly string EXCEPTION_MESSAGE = "";
        public static readonly string ERROR_MESSAGE = "";
        public static readonly string SUCCESS_MESSAGE  = "";

        public class Administration
        {
            public class User
            {
                public const string LIST = "LIST";
            }
        }
    }
}
