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
    
    public partial class udp_SelectIngredient_sel_Result
    {
        public int product_id { get; set; }
        public string product_code { get; set; }
        public string product_name { get; set; }
        public byte[] product_pic { get; set; }
        public string description { get; set; }
        public Nullable<bool> is_enabled { get; set; }
        public Nullable<bool> is_del { get; set; }
        public Nullable<System.DateTime> create_date { get; set; }
        public Nullable<int> create_by { get; set; }
        public Nullable<System.DateTime> update_date { get; set; }
        public Nullable<int> update_by { get; set; }
        public Nullable<int> subcategories_id { get; set; }
        public Nullable<int> warehouse_default { get; set; }
        public Nullable<int> product_unit { get; set; }
        public string unit_name { get; set; }
    }
}
