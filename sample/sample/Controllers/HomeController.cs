using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace sample.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        private PatientRepository repo = new PatientRepository();
        public ActionResult Index()
        {
            
            return View();
        }


        
        [HttpGet]
        public ActionResult Registration()
        {
            /*
            DoctorRepository doctorRepo = new DoctorRepository();
            List<SelectListItem> selectDoc = new List<SelectListItem>();

            foreach(Doctor d in doctorRepo.GetAll())
            {
                SelectListItem Option = new SelectListItem();
                Option.Text = d.Name;
                Option.Value = d.Id.ToString();
                selectDoc.Add(Option);
            }
            ViewBag.Doctors = selectDoc;
             */
            
            return View();
        }

        [HttpPost , ActionName("Registration")]
        public ActionResult RegistrationPost(Patient p)
        {
            if(ModelState.IsValid)
            {
                this.repo.Insert(p);
                return RedirectToAction("../Patient/Index");
            }

            else
            {
               /*
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
                */

                return View();
            }
                
        }

    }
}
