using MSS_YAMBOLY_GEOLOCATION.Services.ODataService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAMBOLY.GESTIONRUTAS.HELPER;
using YAMBOLY.GESTIONRUTAS.MODEL;

namespace YAMBOLY.GESTIONRUTAS.DATAAACCESS.GeoLocation
{
    public class @MSS_GEOSHAPEDataAccess
    {
        public List<MSS_GEOSHAPEType> GetList(DataContext dataContext)
        {
            return dataContext.oDataService.MSS_GEOSHAPE.ToList();
        }

        public string GetInsertQueryIfExists(DataContext dataContext, TreeViewNode model)
        {
            var query = string.Empty;
            var exists = dataContext.oDataService.MSS_GEOSHAPE.Where(x => x.U_ID == model.Id && x.U_SHAPETYPE == ((int)model.ShapeType).ToString()) != null;
            if (exists)
            {
                int key = dataContext.oDataService.MSS_GEOSHAPE.ToList().OrderBy(x => x.Code).FirstOrDefault().Code.ToInteger() + 1;
                query = GetInsertQuery(key.ToString(), key.ToString(), key, (int)model.ShapeType, model.Id);
            }
            return query;
        }

        private string GetInsertQuery(string code, string name, int docEntry, int shapeType, string shapeId)
        {
            return GetQuery(EmbebbedFileName.MSS_GEOSHAPE_Insert).Replace("PARAM1", code)
                                                                 .Replace("PARAM2", name)
                                                                 .Replace("PARAM3", docEntry.ToString())
                                                                 .Replace("PARAM4", shapeType.ToString())
                                                                 .Replace("PARAM5", shapeId);
        }

        public string GetQuery(EmbebbedFileName embebbedFileName)
        {
            var query = XMLHelper.GetXMLString(System.Reflection.Assembly.GetExecutingAssembly(), embebbedFileName);
            query = query.Substring(0, query.IndexOf("BEGINQUERY"));
            query = query.Substring(query.IndexOf("BEGINQUERY") + "BEGINQUERY".Length);
            return query;
        }
    }
}
