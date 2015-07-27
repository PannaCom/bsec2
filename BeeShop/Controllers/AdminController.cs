using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BeeShop.Models;
using Newtonsoft.Json;
namespace BeeShop.Controllers
{
    public class AdminController : Controller
    {
        //
        // GET: /Admin/
        private beeshopEntities db = new beeshopEntities();
        public ActionResult Index()
        {
            return View();
        }
        // *
        // * Category function, view, method....
        // * 
        // * 
        //public ActionResult Category()
        //{
        //    //var p=(from q in db.categories select q).OrderBy(o=>o.depth).ThenBy(o=>o.name)
        //    return View();
        //}
        //public ActionResult Category_Add(int? parent) {
        //    ViewBag.parent = parent;
        //    return View();
        //}
        //public string Category_Add_New(string name, string description, string urlkey, byte isactive, byte inmenu,int? parent)
        //{
        //    try
        //    {
        //        category cate = new category();
        //        cate.name = name;
        //        cate.description = description;
        //        cate.urlkey = urlkey;
        //        cate.isactive = isactive;
        //        cate.inmenu = inmenu;
        //        cate.deleted = 0;
        //        cate.depth = 0;
        //        if (parent == null) parent = -1;
        //        cate.parent = parent;
        //        db.categories.Add(cate);
        //        db.SaveChanges();                
        //    }
        //    catch (Exception ex) {
        //        return ex.ToString();
        //    }
        //    return "1";
        //}
        //public string getRootCategoryList() {
        //    var p = (from q in db.categories where q.parent == -1 select q).ToList();
        //    return JsonConvert.SerializeObject(p);
        //}
    }
}
