using PagedList;
using System;
using System.Collections.Generic;
using YAMBOLY.GESTIONRUTAS.MODEL;

namespace YAMBOLY.GESTIONRUTAS.VIEWMODEL.Administration.Rol
{
    public class RolListViewModel
    {
        public RolListViewModel()
        {
            ViewList = new List<Views>();
            ViewGroupList = new List<ViewGroup>();
            RolesViewList = new List<RolesViews>();
        }

        public List<Views> ViewList { get; set; }
        public List<ViewGroup> ViewGroupList { get; set; }
        public List<RolesViews> RolesViewList { get; set; }
        public int? RolId { get; set; }
    }
}
