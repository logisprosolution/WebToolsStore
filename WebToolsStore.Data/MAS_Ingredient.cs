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
    public partial class MAS_Ingredient
    {
        public int ingredient_id { get; set; }
        public Nullable<int> ingredient_product { get; set; }
        public Nullable<int> product_id { get; set; }
        public Nullable<int> product_unit { get; set; }
        public Nullable<int> product_qty { get; set; }
        public Nullable<bool> is_default { get; set; }
        public Nullable<bool> is_enabled { get; set; }
        public Nullable<bool> is_del { get; set; }
        public Nullable<System.DateTime> create_date { get; set; }
        public Nullable<int> create_by { get; set; }
        public Nullable<System.DateTime> update_date { get; set; }
        public Nullable<int> update_by { get; set; }
        public string product_code { get; set; }
        public string product_name { get; set; }
        public string unit_name { get; set; }
        public virtual MAS_Product MAS_Product { get; set; }
        public string ids { get; set; }
    }
}
