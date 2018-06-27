using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YAMBOLY.GESTIONRUTAS.VIEWMODEL.Administration
{
    public class UserViewModel
    {
        public int? Id { get; set; }
        public string Username { get; set; }
        public string Pass { get; set; }
        public int RolId { get; set; }
    }
}
