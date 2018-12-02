using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace sample.Controllers
{
    public class AdminController : Controller
    {
        private AdminRepository repo = new AdminRepository();
        private PatientRepository repoP = new PatientRepository();
        //
        // GET: /Admin/

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AdminLogin(Admin a)
        {
            Admin a1 = this.repo.GetLogin(a);
            if (a1 != null)
            {
                Session["ADMIN"] = a1.id;
                return RedirectToAction("UserList");
            }
            else
            {
                return RedirectToAction("Login");
            }


        }

        [HttpGet]
        public ActionResult UserList()
        {
           
            
           return View(this.repoP.GetAll());
        }

        

        [HttpGet]
        public ActionResult Delete(int id)
        {
            return View(this.repoP.Get(id));
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            this.repoP.Delete(id);
            return RedirectToAction("UserList");
        }

        public ActionResult Details(int id)
        {

            return View(this.repoP.Get(id));
        }
        /*
        [HttpGet]
        public ActionResult Reg()
        {
            DoctorRepository doctorRepo = new DoctorRepository();
            List<SelectListItem> selectDoc = new List<SelectListItem>();

            foreach (Doctor d in doctorRepo.GetAll())
            {
                SelectListItem Option = new SelectListItem();
                Option.Text = d.Name;
                Option.Value = d.Id.ToString();
                selectDoc.Add(Option);
            }
            ViewBag.Doctors = selectDoc;
            return View();
        }

        [HttpPost, ActionName("Reg")]
        public ActionResult RegPost(Patient p)
        {
            if (ModelState.IsValid)
            {
                this.repoP.Insert(p);
                return RedirectToAction("D");
            }
            else
            {
                return View();
            }
        }
        public ActionResult D()
        {
            return View();
        }
        */

    }
}
