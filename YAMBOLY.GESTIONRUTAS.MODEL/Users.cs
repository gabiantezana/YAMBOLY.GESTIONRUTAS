//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace YAMBOLY.GESTIONRUTAS.MODEL
{
    using System;
    using System.Collections.Generic;
    
    public partial class Users
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public byte[] Pass { get; set; }
        public Nullable<bool> isActive { get; set; }
        public Nullable<int> RolId { get; set; }
        public string Nombres { get; set; }
        public string Documento { get; set; }
        public string Correo { get; set; }
        public string Telefono { get; set; }
    
        public virtual Roles Roles { get; set; }
    }
}
