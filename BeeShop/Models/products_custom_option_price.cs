//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BeeShop.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class products_custom_option_price
    {
        public long id { get; set; }
        public Nullable<int> option_id { get; set; }
        public Nullable<byte> store_id { get; set; }
        public Nullable<decimal> price { get; set; }
        public string price_type { get; set; }
    }
}
