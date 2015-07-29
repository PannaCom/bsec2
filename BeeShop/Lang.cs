using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BeeShop
{
    public class Lang
    {
        //For Administrator

        //Menu
        public static string menu_home = "Admin Home";
        public static string menu_catalogue = "Catalogue";
        public static string menu_category = "Category";
        public static string menu_product = "Products";

        //Category
        public static string category_index_header = "Category List";
        public static string category_add_header = "Add New Category";
        public static string category_edit_header = "Update Category";
        public static string category_add_header_notice = "* is required field";
        public static string category_add_header_add_root = "Add Root Category";
        public static string category_add_header_add_sub = "Add Sub Category";
        public static string category_add_header_edit = "Edit";
        public static string category_add_header_delete = "Delete";
        public static string category_field_name = "Name *";
        public static string category_field_des = "Description";
        public static string category_field_urlkey = "Url key";
        public static string category_field_isactive = "Is Active *";
        public static string category_field_inmenu = "Include in Navigation Menu *";
        public static string category_field_parent_category = "Belong Parent Category *";
        public static string category_field_order_no = "Order No";
        public static string category_root_name = "Root Category";

        //Atributes
        public static string atribute_index_header = "Atributes Group";
        public static string atribute_add_header = "Add New Atribute";
        public static string atribute_edit_header = "Update Atribute";
        public static string atribute_add_header_notice = "* is required field";
        public static string atribute_add_header_add_root = "Add Root Atribute";
        public static string atribute_add_header_add_sub = "Add Sub Atribute";
        public static string atribute_add_header_edit = "Edit";
        public static string atribute_add_header_delete = "Delete";
        public static string atribute_field_name = "Name *";
        public static string atribute_field_des = "Description";
        public static string atribute_field_type = "Type";
        public static string atribute_field_default_value = "Default Value";
        public static string atribute_field_required = "Required";
        public static string atribute_field_apply_to = "Apply To";
        public static string atribute_field_comparable = "Comparable";
        public static string atribute_field_validate = "Validate"; 
        public static string atribute_field_parent_atribute = "Belong Parent Atribute *";
        public static string atribute_field_order_no = "Order No";
        public static string atribute_root_name = "Root Atribute";

        //Products
        public static string product_add_header = "Add New Products";
        public static string product_add_header_notice = "* is required field";
        public static string product_tab1 = "General";
        public static string product_tab2 = "Prices";
        public static string product_tab3 = "Image";
        public static string product_tab4 = "Inventory";
        public static string product_tab5 = "Data";
        public static string product_tab6 = "Categories";
        public static string product_tab7 = "Related Products";
        public static string product_tab8 = "Up-Sells";
        public static string product_tab9 = "Cross-Sells";
        public static string product_tab10 = "Custom Options";
        public static string product_field_type = "Product Type";
        public static string product_field_name = "Name";
        public static string product_field_atribute_group = "Atribute Group";

        //Alert
        public static string alert_save_success = "Saved";
        public static string alert_save_not_success = "Can not save, some errors occur!";
        public static string alert_delete_not_success = "Can not delete, some errors occur!";
        public static string alert_move_not_success = "Can not move now, some errors occur!";
        public static string alert_input_name_field = "type name!";
        public static string alert_edit_item = "choose item for edit!";
    }
}