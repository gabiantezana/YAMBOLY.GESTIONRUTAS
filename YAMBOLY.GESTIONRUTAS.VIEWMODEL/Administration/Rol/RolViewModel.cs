using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YAMBOLY.GESTIONRUTAS.VIEWMODEL.Administration.Rol
{
    public class RolViewModel
    {
        public int? RolId { get; set; }

        [Required]
        [Display(Name = "Nombre")]
        public string RolName { get; set; }

        [Required]
        [Display(Name = "Descripción")]
        public string RolDescription { get; set; }
    }
}
