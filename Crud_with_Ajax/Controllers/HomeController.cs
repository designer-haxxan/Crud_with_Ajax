using Crud_with_Ajax.Models;
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