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
    public partial class MAS_Warehouse
    {
        public MAS_Warehouse()
        {
            this.DOC_Detail = new HashSet<DOC_Detail>();
        }
    
        public int warehouse_id { get; set; }
        public string warehouse_code { get; set; }
        public string warehouse_name { get; set; }
        public string warehouse_address { get; set; }
        public string warehouse_tel { get; set; }
        public string warehouse_contact { get; set; }
        public Nullable<bool> is_del { get; set; }
        public Nullable<bool> is_enabled { get; set; }
        public Nullable<System.DateTime> create_date { get; set; }
        public Nullable<int> create_by { get; set; }
        public Nullable<System.DateTime> update_date { get; set; }
        public Nullable<int> update_by { get; set; }
    
        public virtual ICollection<DOC_Detail> DOC_Detail { get; set; }
    }
}
