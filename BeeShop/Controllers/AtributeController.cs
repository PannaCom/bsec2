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
    public class AtributeController : Controller
    {
        //
        // GET: /Atribute/
        private beeshopEntities db = new beeshopEntities();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Add(int? parent)
        {
            ViewBag.parent = parent;
            //ViewBag.depth = depth;            
            return View();
        }
        public string Add_New(string name, string description,int? parent)
        {
            try
            {
                if (parent == null) parent = -1;
                //if (depth == null) depth = -1;
                //Get max order no
                int? max_order_no = db.atributes.Where(o => o.parent == parent).Max(o => o.order_no);
                if (max_order_no == 0 || max_order_no == null)
                    max_order_no = 1;
                else
                    max_order_no = max_order_no + 1;
                atribute att = new atribute();
                att.name = name;
                att.des = description;
                att.deleted = 0;
                //cate.depth = 0;                
                att.parent = parent;
                //cate.depth = depth + 1;
                att.order_no = max_order_no;
                db.atributes.Add(att);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
            return "1";
        }
        public ActionResult Edit(int id)
        {
            atribute att = db.atributes.Find(id);
            if (att != null)
            {
                ViewBag.id = id;
                ViewBag.name = att.name;
                ViewBag.description = att.des;               
                ViewBag.parent = att.parent;
                ViewBag.order_no = att.order_no;
            }
            return View();
        }
        public string Edit_Update(int id, string name, string description, int? parent, int order_no)
        {
            try
            {
                //string query="update category set name="
                atribute att = db.atributes.Find(id);
                att.name = name;
                att.des = description;               
                att.parent = parent;
                //cate.depth = depth;
                att.order_no = order_no;
                db.Entry(att).State = EntityState.Modified;
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
            return "1";
        }
        public string Delete(int id)
        {
            try
            {
                string query = "update atributes set deleted=1 where id=" + id;
                db.Database.ExecuteSqlCommand(query);
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
            return "1";
        }
        public string getRootAtributeList() {
            var p = (from q in db.atributes where q.deleted == 0 && q.parent == -1 select new { name = q.name, id = q.id, order_no = q.order_no }).OrderBy(o => o.order_no).ToList();
            return JsonConvert.SerializeObject(p);
        }
        //Lấy ra các node mà có parent=id
        public string getAllChildOfNode(int id)
        {
            var p = (from q in db.atributes where q.deleted == 0 && q.parent == id select new { name = q.name, id = q.id, order_no = q.order_no }).OrderBy(o => o.order_no).ToList();
            return JsonConvert.SerializeObject(p);
        }
        public string getAllNodeAtribute(int idselected, int parentid)
        {
            string select = "<select id=parent name=parent><option value=-1 depth=0>" + Lang.category_root_name + "</option>";
            var p = (from q in db.atributes where q.deleted == 0 && q.parent == -1 select new { id = q.id, name = q.name, parent = q.parent, description = q.des, deleted = q.deleted, order_no = q.order_no }).OrderBy(o => o.order_no).ToList();
            for (int i = 0; i < p.Count; i++)
            {
                if (p[i].id != parentid)
                {
                    select += "<option value=\"" + p[i].id + "\" >&nbsp;&nbsp;" + p[i].name + "</option>";
                }
                else
                {
                    select += "<option value=\"" + p[i].id + "\" selected>&nbsp;&nbsp;" + p[i].name + "</option>";
                }
                select += getAllChild(p[i].id, idselected, parentid, 1);
            }
            select += "</select>";
            return select;
        }
        public string getAllChild(int id, int idselected, int parentid, int DEPTH)
        {
            string option = "";
            var p1 = (from q in db.atributes where q.deleted == 0 && q.parent == id select new { id = q.id, name = q.name, parent = q.parent, description = q.des, deleted = q.deleted, order_no = q.order_no }).OrderBy(o => o.order_no).ToList();
            for (int i = 0; i < p1.Count; i++)
            {
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
                    else
                    {
                        option += "<option value=\"" + p1[i].id + "\" selected>" + spacer + "-" + p1[i].name + "</option>";
                    }
                    option += getAllChild(p1[i].id, idselected, parentid, DEPTH + 1);
                }
                //else {
                //    option += "<option value=\"" + p1[i].id + "\" depth=\"" + p1[i].depth + "\" selected>-" + p1[i].name + "</option>";
                //}
            }
            return option;
        }
        public string moveCategoryAndSort(int fromid, int toid)
        {
            try
            {
                var fromidparent = db.atributes.Where(o => o.id == fromid).FirstOrDefault().parent;
                var toidparent = db.atributes.Where(o => o.id == toid).FirstOrDefault().parent;
                if (fromidparent == toidparent)
                {
                    var order_from = db.atributes.Where(o => o.id == fromid).FirstOrDefault().order_no;
                    var order_to = db.atributes.Where(o => o.id == toid).FirstOrDefault().order_no;
                    //Tăng các order no của các atribute sau atribute được chèn lên 1
                    string query = "update atributes set order_no=order_no+1 where parent=" + fromidparent + " and order_no<=" + order_from + "  and order_no>=" + order_to;
                    db.Database.ExecuteSqlCommand(query);
                    //set order_no cho atribute này
                    query = "update atributes set order_no=" + order_to + " where id=" + fromid;
                    db.Database.ExecuteSqlCommand(query);
                }
                else
                {
                    //Đẩy thứ tự xếp hạng của các atributes cùng nhánh lên 1
                    string query = "update atributes set order_no=order_no+1 where parent=" + toid + " and order_no>=1";
                    db.Database.ExecuteSqlCommand(query);
                    query = "update atributes set parent=" + toid + ",order_no=1 where id=" + fromid;
                    db.Database.ExecuteSqlCommand(query);
                }
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
            return "1";
        }
    }
}
