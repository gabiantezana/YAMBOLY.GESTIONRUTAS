using MSS_YAMBOLY_GEOLOCATION.Services.ODataService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAMBOLY.GESTIONRUTAS.MODEL;

namespace YAMBOLY.GESTIONRUTAS.DATAAACCESS.Administration
{
    public class EmployeeDataAccess
    {
        //Listado de empleados
        public IEnumerable<A1A_LIEMType> GetList(DataContext dataContext)
        {
            return dataContext.oDataService.A1A_LIEM;
        }

        //Listado de centros de costo
        public IEnumerable<OOCRType> GetCostingCodesList(DataContext dataContext)
        {
            return dataContext.oDataService.OOCR;
        }

        //Listado  de órdenes de fabricación
        public IEnumerable<OWORType> GetOrdersList(DataContext dataContext)
        {
            return dataContext.oDataService.OWOR;
        }
    }
}
