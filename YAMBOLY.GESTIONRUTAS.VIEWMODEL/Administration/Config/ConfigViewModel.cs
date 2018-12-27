using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YAMBOLY.GESTIONRUTAS.VIEWMODEL.Administration.Config
{
    public class ConfigViewModel
    {
        [Display(Name = "Id")]
        [Required(ErrorMessage = "Identificador requerido")]
        public int? Id { get; set; }

        [Display(Name = "Key")]
        [Required(ErrorMessage = "Identificador requerido")]
        public string Key { get; set; }

        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "Identificador requerido")]
        public string Name { get; set; }

        [Display(Name = "Id")]
        [Required(ErrorMessage = "Identificador requerido")]
        public string Description { get; set; }

        [Display(Name = "Id")]
        [Required(ErrorMessage = "Identificador requerido")]
        public string Value { get; set; }
    }
}
