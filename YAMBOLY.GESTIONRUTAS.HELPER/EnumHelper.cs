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
        SUPERADMINISTRATOR = 0,
        ADMINISTRATOR = 1,
    }
    public enum SessionKey
    {
        UserId,
        Rol,
        UserName,
        UserNames,
        Views,
    }

    #region MODAL SIZE
    public enum ModalSize
    {
        Normal,
        Small,
        Large
    }
    #endregion
}
