using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YAMBOLY.GESTIONRUTAS.HELPER
{
    public class EnumHelper
    {
    }
    public enum MessageType
    {
        Success,
        Warning,
        Info,
        Error
    }
    public enum AppRol
    {
        SuperAdministrator,
        Administrator,
    }
    public enum SessionKey
    {
        UserId,
        Rol,
        UserName,
        UserNames,
        Views,
    }

}
