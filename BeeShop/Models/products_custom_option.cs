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
    
    public partial class products_custom_option
    {
        public long id { get; set; }
        public Nullable<int> products_id { get; set; }
        public string type { get; set; }
        public Nullable<byte> is_require { get; set; }
        public string sku { get; set; }
        public Nullable<int> max_characters { get; set; }
        public string file_extension { get; set; }
        public Nullable<int> image_size_x { get; set; }
        public Nullable<int> image_size_y { get; set; }
        public Nullable<int> sort_order { get; set; }
    }
}
