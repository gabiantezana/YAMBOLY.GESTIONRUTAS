using MSS_YAMBOLY_GEOLOCATION.Services.ODataService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAMBOLY.GESTIONRUTAS.MODEL;

namespace YAMBOLY.GESTIONRUTAS.DATAAACCESS.GeoLocation
{
    public class @MSS_GEOSHAPE_DDataAccess
    {
        public List<MSS_GEOSHAPE_DType> GetList(DataContext dataContext)
        {
            return dataContext.oDataService.MSS_GEOSHAPE_D.ToList();
        }
    }
}
