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
    public partial class USR_User_Role
    {
        public int running_id { get; set; }
        public int role_id { get; set; }
        public int user_id { get; set; }
        public string user_name { get; set; }
        public Nullable<bool> is_enabled { get; set; }
        public Nullable<bool> is_del { get; set; }
        public Nullable<System.DateTime> create_date { get; set; }
        public Nullable<int> create_by { get; set; }
        public Nullable<System.DateTime> update_date { get; set; }
        public Nullable<int> update_by { get; set; }
    
        public virtual USR_Role USR_Role { get; set; }
        public virtual USR_User USR_User { get; set; }
    }
}
