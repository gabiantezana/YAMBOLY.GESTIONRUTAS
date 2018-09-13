using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAMBOLY.GESTIONRUTAS.DATAAACCESS.Administration;
using YAMBOLY.GESTIONRUTAS.HELPER;
using YAMBOLY.GESTIONRUTAS.MODEL;
using YAMBOLY.GESTIONRUTAS.VIEWMODEL.Administration.Employee;

namespace YAMBOLY.GESTIONRUTAS.LOGIC.Administration
{
    public class EmployeeLogic
    {
        public RegisterHoursViewModel GetRegisterHoursViewModel(DataContext dataContext)
        {
            var model = new RegisterHoursViewModel();
            model.CentroCostos1JList = GetCostingCodesList(dataContext, 1);
            model.CentroCostos2JList = GetCostingCodesList(dataContext, 2);
            model.CentroCostos3JList = GetCostingCodesList(dataContext, 3);
            model.CentroCostos4JList = GetCostingCodesList(dataContext, 4);
            model.CentroCostos5JList = GetCostingCodesList(dataContext, 5);
            model.EmployeeHoursList = GetEmployeeHoursList(dataContext);
            return model;
        }

        public List<EmployeeHours> GetEmployeeHoursList(DataContext dataContext)
        {
            return new EmployeeDataAccess().GetList(dataContext).Select(x => new EmployeeHours() { EmployeeId = x.Code, EmployeeNames = x.Name, Hours = 0 }).ToList();
        }

        /// <summary>
        /// Listado de empleados
        /// </summary>
        public List<JsonEntityTwoString> GetEmployeeJList(DataContext dataContext)
        {
            return new EmployeeDataAccess().GetList(dataContext).Select(x => new JsonEntityTwoString() { id = x.Code, text = x.Name }).ToList();
        }

        /// <summary>
        //Listado de centros de costo
        /// </summary>
        public List<JsonEntityTwoString> GetCostingCodesList(DataContext dataContext, int? level)
        {
            return new EmployeeDataAccess().GetCostingCodesList(dataContext).Select(x => new JsonEntityTwoString() { id = x.OcrCode, text = x.OcrName }).ToList();
        }

        /// <summary>
        /// Listado  de órdenes de fabricación
        /// </summary>
        public List<JsonEntity> GetOrdersList(DataContext dataContext)
        {
            return new EmployeeDataAccess().GetOrdersList(dataContext).Select(x => new JsonEntity() { id = x.DocNum, text = x.DocNum + " " + x.ItemCode + " " + x.ItemName }).ToList();
        }
    }
}
