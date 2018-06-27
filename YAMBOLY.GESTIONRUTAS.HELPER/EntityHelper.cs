using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YAMBOLY.GESTIONRUTAS.HELPER
{
    class EntityHelper
    {
    }
    public class JsonEntity
    {
        public Int32 id { get; set; }
        public String text { get; set; }
    }
    public class JsonEntityTwoString
    {
        public String id { get; set; }
        public String text { get; set; }
    }
    public class JsonEntityGroup
    {
        public List<JsonEntity2> children { get; set; }
        public Int32 id { get; set; }
        public String text { get; set; }
        public String search { get; set; }
    }

    public class JsonEntity2
    {
        public Int32 id { get; set; }
        public String text { get; set; }
        public Int32 type { get; set; }
    }

    public class TempDataEntity
    {
        public MessageType TipoMensaje { get; set; }
        public String Mensaje { get; set; }
    }
}
