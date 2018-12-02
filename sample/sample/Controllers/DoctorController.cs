using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace sample.Controllers
{
    public class DoctorController : Controller
    {
        //
        // GET: /Doctor/

        private DataContext context = new DataContext();
        private DoctorRepository repoD = new DoctorRepository();
        private PatientRepository repoP = new PatientRepository();
        
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]

        public ActionResult AfterLogin(Doctor d)
        {
            Doctor D1 = this.repoD.GetLogin(d);
            if (D1 != null)
            {
                Session["DOCTOR"] = D1.Id;
                return View(D1);
            }
            else
            {
                TempData["Err"] = "Wrong UserName or Password";
                return RedirectToAction("Login");
            }
        }

        public ActionResult GetPatient()
        {

            int id = Convert.ToInt32(Session["DOCTOR"]);
            return View(this.repoP.GetDoctor(id));
        }

        public ActionResult GetPatientDetails(int id)
        {
            return View(this.repoP.Get(id));
        }

        public ActionResult GetPatientPrescription(int id)
        {

            List<Image> imglist = this.context.Images.Where(x => x.PatientId == id).ToList();
            return View(imglist);
        }

    }
}
