﻿using MSS_YAMBOLY_GEOLOCATION.Services.ODataService;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;
using YAMBOLY.GESTIONRUTAS.DATAAACCESS.GeoLocation;
using YAMBOLY.GESTIONRUTAS.DATAAACCESS.Queries;
using YAMBOLY.GESTIONRUTAS.HELPER;
using YAMBOLY.GESTIONRUTAS.MODEL;

namespace YAMBOLY.GESTIONRUTAS.LOGIC.GeoLocation
{
    public class @MSS_ZONALogic
    {
        private List<MSS_ZONAType> GetSAPList(DataContext dataContext)
        {
            return new MSS_ZONADataAccess().GetList(dataContext);
        }

        public List<Zone> GetList(DataContext dataContext)
        {
            return GetSAPList(dataContext).Select(x => new Zone()
            {
                Id = x.Code,
                Name = x.Name,
                GeoOptions = new MapLogic().GetGeoOptionsFromCoordinates(x.U_COORDINATESARRAY, ShapeType.Zone)
            }).ToList();
        }


        public string GetQuery(DataContext dataContext, TreeViewNode zone)
        {
            string coordinates = string.Empty;
            if (zone.GeoOptions != null)
                coordinates = new MapLogic().GetCoordinatesArray(zone.GeoOptions, PolygonType.Zone);

            var query = Queries.GetStringContent(EmbebbedFileName.MSS_ZONA_Update);
            query = query.Replace("PARAM1", zone.Id)
                         .Replace("PARAM2", coordinates);

            return query;
        }

        public void DoQuery(string finalQuery)
        {
            var response = WebHelper.GetJsonResponse(finalQuery, null, null);

        }

    }
}
