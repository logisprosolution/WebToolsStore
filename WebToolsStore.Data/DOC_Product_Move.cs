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
    public partial class DOC_Product_Move
    {
        public int detail_id { get; set; }
        public int product_id { get; set; }
        public Nullable<int> unit_id { get; set; }
        public Nullable<int> unit_value { get; set; }
        public Nullable<int> detail_qty { get; set; }
        public Nullable<decimal> product_price { get; set; }
        public Nullable<decimal> product_cost { get; set; }
        public Nullable<decimal> prduct_vat { get; set; }
        public Nullable<bool> is_del { get; set; }
        public Nullable<System.DateTime> create_date { get; set; }
        public Nullable<int> warehouse_id { get; set; }
    }
}
