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
    
    public partial class customer_address
    {
        public long id { get; set; }
        public Nullable<int> customer_id { get; set; }
        public string company { get; set; }
        public string street_address { get; set; }
        public string city { get; set; }
        public string country { get; set; }
        public string province { get; set; }
        public string postal_code { get; set; }
        public string phone { get; set; }
        public string fax { get; set; }
    }
}
