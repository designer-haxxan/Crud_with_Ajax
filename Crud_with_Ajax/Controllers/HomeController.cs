using Crud_with_Ajax.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Crud_with_Ajax.Controllers
{
    public class HomeController : Controller
    {

        crud_ajaxEntities db = new crud_ajaxEntities();
        public ActionResult Index()
        {
            List<tbl_depart> deplis = db.tbl_depart.ToList();
            ViewBag.Departlist = new SelectList(deplis, "id", "name");
            return View();
        }
        public JsonResult GetStudentList()
        {
            List<StudentViewModel> std = db.tbl_students.Where(x => x.isdeleted == false).Select(x => new StudentViewModel {
                id = x.id,
                name = x.name,
                email = x.email,
                dpname=x.tbl_depart.name
            }
            ).ToList();
            return Json(std,JsonRequestBehavior.AllowGet);
        }
        public JsonResult deldata(Int64 stdid)
        {
            bool result = false;
            tbl_students stu = db.tbl_students.SingleOrDefault(x => x.isdeleted == false && x.id == stdid);
            if (stu!=null)
            {
                stu.isdeleted = true;
                db.SaveChanges();
                result = true;
            }
            return Json(result,JsonRequestBehavior.AllowGet);
        }
        public JsonResult savedata(StudentViewModel model)
        {
            var result = false;
            try
            {
                if (model.id > 0)
                {
                    tbl_students stu = db.tbl_students.SingleOrDefault(x => x.isdeleted == false && x.id == model.id);
                    stu.name = model.name;
                    stu.email = model.email;
                    stu.dpt = model.dpt;
                    db.SaveChanges();
                    result = true;
                }
                else
                {
                    tbl_students stu = new tbl_students();
                    stu.name = model.name;
                    stu.email = model.email;
                    stu.dpt = model.dpt;
                    stu.isdeleted = false;
                    db.tbl_students.Add(stu);
                    db.SaveChanges();
                    result = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Json(result,JsonRequestBehavior.AllowGet);
        }
        public JsonResult getstudentbyid(Int64 stdid)
        {
            tbl_students model = db.tbl_students.Where(x => x.id == stdid).SingleOrDefault();
            string value = string.Empty;
            value = JsonConvert.SerializeObject(model, Formatting.Indented, new JsonSerializerSettings
            {
                ReferenceLoopHandling=ReferenceLoopHandling.Ignore
            });
            return Json(value,JsonRequestBehavior.AllowGet);
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}