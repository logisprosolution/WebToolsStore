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
    public partial class MAS_Subcategories
    {
        public MAS_Subcategories()
        {
            this.MAS_Product = new HashSet<MAS_Product>();
        }
    
        public int subcategories_id { get; set; }
        public string subcategories_code { get; set; }
        public string subcategories_name { get; set; }
        public Nullable<double> subcategories_index { get; set; }
        public string description { get; set; }
        public Nullable<bool> is_del { get; set; }
        public Nullable<bool> is_enabled { get; set; }
        public Nullable<int> categories_id { get; set; }
        public Nullable<System.DateTime> create_date { get; set; }
        public Nullable<int> create_by { get; set; }
        public Nullable<System.DateTime> update_date { get; set; }
        public Nullable<int> update_by { get; set; }
    
        public virtual MAS_Categories MAS_Categories { get; set; }
        public virtual ICollection<MAS_Product> MAS_Product { get; set; }
    }
}
