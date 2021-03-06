//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebToolsStore.Data
{
    using System;
    using System.Collections.Generic;
    
    [Serializable]
    public partial class USR_Role
    {
        public USR_Role()
        {
            this.USR_Role_Submenu = new HashSet<USR_Role_Submenu>();
            this.USR_User_Role = new HashSet<USR_User_Role>();
        }
    
        public int role_id { get; set; }
        public string role_code { get; set; }
        public string role_name { get; set; }
        public Nullable<int> role_value { get; set; }
        public Nullable<bool> is_del { get; set; }
        public Nullable<bool> is_enabled { get; set; }
        public Nullable<System.DateTime> create_date { get; set; }
        public Nullable<int> create_by { get; set; }
        public Nullable<System.DateTime> update_date { get; set; }
        public Nullable<int> update_by { get; set; }
    
        public virtual ICollection<USR_Role_Submenu> USR_Role_Submenu { get; set; }
        public virtual ICollection<USR_User_Role> USR_User_Role { get; set; }
    }
}
