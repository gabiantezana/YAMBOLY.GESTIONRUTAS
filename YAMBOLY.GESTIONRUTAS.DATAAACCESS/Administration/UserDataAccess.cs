using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAMBOLY.GESTIONRUTAS.HELPER;
using YAMBOLY.GESTIONRUTAS.MODEL;
using YAMBOLY.GESTIONRUTAS.VIEWMODEL.Administration;
using YAMBOLY.GESTIONRUTAS.VIEWMODEL.General;

namespace YAMBOLY.GESTIONRUTAS.DATAAACCESS.Administration
{
    public class UserDataAccess
    {
        public List<Users> Get(DataContext dataContext)
        {
            return dataContext.context.Users.ToList();
        }

        public Users Get(DataContext dataContext, int? userId)
        {
            return dataContext.context.Users.Find(userId);
        }

        public void AddUpdate(DataContext dataContext, UserViewModel model)
        {
            Users user = new Users();
            Boolean itsUpdate = dataContext.context.Users.Find(model.Id) != null;
            if (itsUpdate)
            {
                user = dataContext.context.Users.Find(user.UserId);
            }
            else
            {
                var byteArrayPassword = EncryptionHelper.EncryptTextToMemory(ConstantHelper.PASSWORD_DEFAULT, ConstantHelper.ENCRIPT_KEY, ConstantHelper.ENCRIPT_METHOD);
                user.Pass = byteArrayPassword;
            }
            user.UserName = model.Username;
            user.RolId = model.RolId;

            if (itsUpdate)
                dataContext.context.Entry(user);
            else
                dataContext.context.Users.Add(user);
            dataContext.context.SaveChanges();
        }

        public void ChangePassword(DataContext dataContext, int? userId, ChangePasswordViewModel model)
        {
            var entity = dataContext.context.Users.Find(userId);
            if (entity != null)
            {
                entity.Pass = EncryptionHelper.EncryptTextToMemory(model.Password, ConstantHelper.ENCRIPT_KEY, ConstantHelper.ENCRIPT_METHOD);
                dataContext.context.SaveChanges();
            }
        }
    }
}
