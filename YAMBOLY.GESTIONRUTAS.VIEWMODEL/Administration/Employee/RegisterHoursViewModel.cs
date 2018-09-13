using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAMBOLY.GESTIONRUTAS.HELPER;

namespace YAMBOLY.GESTIONRUTAS.VIEWMODEL.Administration.Employee
{
    public class RegisterHoursViewModel
    {
        [Display(Name = "Tipo de empleado")]
        public TipoEmpleado TipoEmpleado { get; set; }

        public DateTime? Fecha { get; set; }

        public List<JsonEntityTwoString> CentroCostos1JList { get; set; }
        [Display(Name = "Dimensión 1")]
        public string CentroCostos1 { get; set; }

        public List<JsonEntityTwoString> CentroCostos2JList { get; set; }
        [Display(Name = "Dimensión 2")]
        public string CentroCostos2 { get; set; }

        public List<JsonEntityTwoString> CentroCostos3JList { get; set; }
        [Display(Name = "Dimensión 3")]
        public string CentroCostos3 { get; set; }

        public List<JsonEntityTwoString> CentroCostos4JList { get; set; }
        [Display(Name = "Dimensión 4")]
        public string CentroCostos4 { get; set; }

        public List<JsonEntityTwoString> CentroCostos5JList { get; set; }
        [Display(Name = "Dimensión 5")]
        public string CentroCostos5 { get; set; }

        public List<EmployeeHours> EmployeeHoursList { get; set; }
    }
}
