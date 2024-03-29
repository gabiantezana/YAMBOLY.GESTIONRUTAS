﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YAMBOLY.GESTIONRUTAS.HELPER
{
    public class ConstantHelper
    {
        public const string PORTALNAME = "Portal de geolocalización";
        public const string PARTNERNAME = "Yamboly SAC";

        public const string PASSWORD_DEFAULT = "12345";
        public const string PASSWORD_HIDDEN = "*****";

        public const int FRECUENCIAVISITAINDEXUDVTABLE = 7;
        public const string CRD1 = "CRD1";


        public static readonly Int32 DEFAULT_PAGE_SIZE = 10;
        public static readonly byte[] ENCRIPT_KEY = { 45, 12, 45, 78, 2, 45, 12, 65, 87, 12, 45, 32, 20, 58, 15, 36, 47, 85, 96, 20, 24, 23, 65, 24 };
        public static readonly byte[] ENCRIPT_METHOD = { 87, 10, 65, 35, 12, 66, 21, 65 };
        public static readonly string EXCEPTION_MESSAGE = "Hubo un error no controlado.";
        public static readonly string ERROR_MESSAGE = "Hubo un error al procesar la operación.";
        public static readonly string SUCCESS_MESSAGE = "Operación finalizada exitosamente.";

        public static readonly string ESTADO_ACTIVO = "Activo";
        public static readonly string ESTADO_INACTIVO = "Inactivo";

        public static string ODATASERVICEURL_KEY = "ODataUrl";
        public static string XSJSPATH_KEY = "XSJSPath";
        public static string HANADBNAME_KEY = "HANADBNAME";

        public static string BEGINQUERY = "--BEGINQUERY";

        public static class QueryParameters
        {
            public static string PARAM0 = "PARAM0";
            public static string PARAM1 = "PARAM1";
            public static string PARAM2 = "PARAM2";
            public static string PARAM3 = "PARAM3";
            public static string PARAM4 = "PARAM4";
        }

        public class Views
        {
            public class Administration
            {
                public const string _PREFIX = "ADMINISTRATION.";
                public static class User
                {
                    private const string PREFIX = _PREFIX + "USER.";

                    public const string LIST = PREFIX + "LIST";
                    public const string CREATE = PREFIX + "CREATE";
                    public const string UPDATE = PREFIX + "UPDATE";
                }

                public static class Rol
                {
                    private const string PREFIX = _PREFIX + "ROL.";

                    public const string LIST = PREFIX + "LIST";
                    public const string CREATE = PREFIX + "CREATE";
                    public const string UPDATE = PREFIX + "UPDATE";
                }

                public static class Employee
                {
                    private const string PREFIX = _PREFIX + "EMPLOYEE.";

                    public const string REGISTERHOURS = PREFIX + "REGISTERHOURS";
                    public const string VIEWREPORTS = PREFIX + "VIEWREPORTS";
                }

                public static class Config
                {
                    private const string PREFIX = _PREFIX + "CONFIG.";
                    public const string VIEW = PREFIX + "VIEW";
                    public const string UPDATE = PREFIX + "UPDATE";
                }
            }

            public class GeoLocation
            {
                public const string _PREFIX = "GEOLOCATION.";
                public static class Map
                {
                    private const string PREFIX = _PREFIX + "MAP.";

                    public const string VIEW = PREFIX + "VIEW";
                    public const string CREATESHAPES = PREFIX + "CREATESHAPES";
                    public const string UPDATESHAPES = PREFIX + "UPDATESHAPES";
                    public const string VIEWREPORTS = PREFIX + "VIEWREPORTS";
                }
            }
        }

        public class Area
        {
            public static readonly string ADMINISTRATION = "Administration";
            public static readonly string GEOLOCATION = "GeoLocation";
        }
    }
}
