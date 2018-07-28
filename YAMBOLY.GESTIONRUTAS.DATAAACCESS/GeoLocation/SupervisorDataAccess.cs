﻿using MSS_YAMBOLY_GEOLOCATION.Services.ODataService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAMBOLY.GESTIONRUTAS.MODEL;

namespace YAMBOLY.GESTIONRUTAS.DATAAACCESS.GeoLocation
{
    public class SupervisorDataAccess
    {
        public List<MSS_SUPEType> GetSAPList(DataContext dataContext)
        {
            return dataContext.oDataService.MSS_SUPE.ToList();
        }
    }
}
