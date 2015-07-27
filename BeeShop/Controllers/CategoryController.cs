using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BeeShop.Models;
using Newtonsoft.Json;
using System.Data;
namespace BeeShop.Controllers
{
    public class CategoryController : Controller
    {
        //
        // GET: /Category/
        private beeshopEntities db = new beeshopEntities();
        
        // *
        // * Category function, view, method....
        // * 
        // * 
        public ActionResult Index()
        {
            //var p=(from q in db.categories select q).OrderBy(o=>o.depth).ThenBy(o=>o.name)
            return View();
        }
        public ActionResult Add(int? parent)
        {
            ViewBag.parent = parent;
            //ViewBag.depth = depth;            
            return View();
        }
        public ActionResult Edit(int id)
        {
            category cate=db.categories.Find(id);
            if (cate!=null){
                ViewBag.id = id;
                ViewBag.name = cate.name;
                ViewBag.description = cate.description;
                ViewBag.urlkey=cate.urlkey;
                ViewBag.isactive = cate.isactive;
                ViewBag.inmenu = cate.inmenu;
                ViewBag.parent = cate.parent;
                ViewBag.order_no = cate.order_no;
            }
            return View();
        }
        public string Edit_Update(int id, string name, string description, string urlkey, byte isactive, byte inmenu, int? parent,int order_no)
        {
            try
            {
                //string query="update category set name="
                category cate = db.categories.Find(id);
                cate.name = name;
                cate.description = description;
                cate.urlkey = urlkey;
                cate.isactive = isactive;
                cate.inmenu = inmenu;
                cate.parent = parent;
                //cate.depth = depth;
                cate.order_no = order_no;
                db.Entry(cate).State = EntityState.Modified;
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
            return "1";
        }
        public string getAllNodeCategory(int idselected, int parentid)
        {
            string select = "<select id=parent name=parent><option value=-1 depth=0>" + Lang.category_root_name + "</option>";
            var p = (from q in db.categories where q.deleted == 0 && q.parent == -1 select new { id=q.id,name = q.name, parent = q.parent, urlkey = q.urlkey, inmenu = q.inmenu, description = q.description, isactive = q.isactive, deleted = q.deleted, order_no = q.order_no }).OrderBy(o => o.order_no).ToList();
            for (int i = 0; i < p.Count; i++) {
                if (p[i].id != parentid)
                {
                    select += "<option value=\"" + p[i].id + "\" >&nbsp;&nbsp;" + p[i].name + "</option>";
                }
                else
                {
                    select += "<option value=\"" + p[i].id + "\" selected>&nbsp;&nbsp;" + p[i].name + "</option>";
                }
                select += getAllChild(p[i].id, idselected, parentid,1);
            }
            select += "</select>";
            return select;
        }
        public string getAllChild(int id, int idselected, int parentid,int DEPTH)
        {
            string option = "";
            var p1 = (from q in db.categories where q.deleted == 0 && q.parent == id select new { id = q.id, name = q.name, parent = q.parent, urlkey = q.urlkey, inmenu = q.inmenu, description = q.description, isactive = q.isactive, deleted = q.deleted, order_no = q.order_no }).OrderBy(o => o.order_no).ToList();
            for (int i = 0; i < p1.Count; i++) {
                if (p1[i].id != idselected)
                {
                    string spacer = "";
                    for (int j = 0; j < DEPTH; j++)
                    {
                        spacer += "&nbsp;&nbsp;&nbsp;&nbsp;";
                    }
                    if (p1[i].id != parentid)
                    {
                        option += "<option value=\"" + p1[i].id + "\" >" + spacer + "-" + p1[i].name + "</option>";
                    }
                    else {
                        option += "<option value=\"" + p1[i].id + "\" selected>" + spacer + "-" + p1[i].name + "</option>";
                    }
                    option += getAllChild(p1[i].id, idselected, parentid, DEPTH+1);
                }
                //else {
                //    option += "<option value=\"" + p1[i].id + "\" depth=\"" + p1[i].depth + "\" selected>-" + p1[i].name + "</option>";
                //}
            }
            return option;
        }
        public string Add_New(string name, string description, string urlkey, byte isactive, byte inmenu, int? parent)
        {
            try
            {
                if (parent == null) parent = -1;
                //if (depth == null) depth = -1;
                //Get max order no
                int? max_order_no = db.categories.Where(o => o.parent == parent).Max(o => o.order_no);
                if (max_order_no == 0 || max_order_no == null)
                    max_order_no = 1;
                else
                    max_order_no = max_order_no + 1;

                category cate = new category();
                cate.name = name;
                cate.description = description;
                cate.urlkey = urlkey;
                cate.isactive = isactive;
                cate.inmenu = inmenu;
                cate.deleted = 0;
                //cate.depth = 0;                
                cate.parent = parent;                
                //cate.depth = depth + 1;
                cate.order_no=max_order_no;
                db.categories.Add(cate);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
            return "1";
        }
        public string Delete(int id) {
            try
            {
                string query = "update category set deleted=1 where id="+id;
                db.Database.ExecuteSqlCommand(query);
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
            return "1";
        }
        public string getRootCategoryList()
        {
            var p = (from q in db.categories where q.deleted == 0 && q.parent == -1 select new { id = q.id, name = q.name, parent = q.parent, urlkey = q.urlkey, inmenu = q.inmenu, description = q.description, isactive = q.isactive, deleted = q.deleted, order_no = q.order_no }).OrderBy(o => o.order_no).ToList();
            return JsonConvert.SerializeObject(p);
        }
        //Lấy ra các node mà có parent=id
        public string getAllChildOfNode(int id)
        {
            var p = (from q in db.categories where q.deleted == 0 && q.parent == id select new { id = q.id, name = q.name, parent = q.parent, urlkey = q.urlkey, inmenu = q.inmenu, description = q.description, isactive = q.isactive, deleted = q.deleted, order_no = q.order_no }).OrderBy(o => o.order_no).ToList();
            return JsonConvert.SerializeObject(p);
        }
        public string moveCategoryAndSort(int fromid, int toid) {
            try
            {
                var fromidparent = db.categories.Where(o => o.id == fromid).FirstOrDefault().parent;
                var toidparent = db.categories.Where(o => o.id == toid).FirstOrDefault().parent;
                if (fromidparent == toidparent)
                {
                    var order_from = db.categories.Where(o => o.id == fromid).FirstOrDefault().order_no;
                    var order_to = db.categories.Where(o => o.id == toid).FirstOrDefault().order_no;
                    //Tăng các order no của các category sau category được chèn lên 1
                    string query = "update category set order_no=order_no+1 where parent=" + fromidparent + " and order_no<=" + order_from + "  and order_no>=" + order_to;
                    db.Database.ExecuteSqlCommand(query);
                    //set order_no cho cate này
                    query = "update category set order_no=" + order_to + " where id=" + fromid;
                    db.Database.ExecuteSqlCommand(query);
                }
                else {
                    //Đẩy thứ tự xếp hạng của các category cùng nhánh lên 1
                    string query = "update category set order_no=order_no+1 where parent=" + toid + " and order_no>=1";
                    db.Database.ExecuteSqlCommand(query);
                    query = "update category set parent="+toid+",order_no=1 where id="+fromid;
                    db.Database.ExecuteSqlCommand(query);                    
                }
            }
            catch (Exception ex) {
                return ex.ToString();
            }
            return "1";
        }
    }
}
