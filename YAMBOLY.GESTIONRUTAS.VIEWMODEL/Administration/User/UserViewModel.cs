using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using YAMBOLY.GESTIONRUTAS.HELPER;

namespace YAMBOLY.GESTIONRUTAS.VIEWMODEL.Administration.User
{
    public class UserViewModel
    {
        public UserViewModel()
        {
            Roles = new List<JsonEntity>();
        }
        public int? UserId { get; set; }

        [Required]
        public string UserName { get; set; }
        public string Pass { get; set; }

        [Required]
        [Display(Name ="Rol")]
        public int? RolId { get; set; }
        public List<JsonEntity> Roles { get; set; }
    }
}
