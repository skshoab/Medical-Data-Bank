using DataLayer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace sample.Controllers
{
    public class PatientController : Controller
    {
        //
        // GET: /Patient/

        private PatientRepository repo = new PatientRepository();
        private DataContext context = new DataContext();
        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AfterLogin(Patient p)
        {
            Patient P1 = this.repo.GetLogin(p);
            if(P1 != null)
            {
               Session["PATIENT"] = P1.Id;
                return View(P1);
            }
            else
            {
                TempData["Err"] = "Wrong UserName or Password";
                return RedirectToAction("Login");
            }
            
            
        }

       
        public ActionResult DashBoard()
        {
            int id =Convert.ToInt32(Session["PATIENT"]);
            return View(this.repo.Get(id));
        }
        [HttpGet]
        public ActionResult EditProfile(int id)
        {

            Patient p1 = this.repo.Get(id);

            DoctorRepository doctorRepo = new DoctorRepository();
            List<SelectListItem> selectDoc = new List<SelectListItem>();

            foreach (Doctor d in doctorRepo.GetAll())
            {
                SelectListItem Option = new SelectListItem();
                Option.Text = d.Name;
                Option.Value = d.Id.ToString();
                if(d.Id == p1.DoctorId)
                {
                    Option.Selected = true;
                }
                selectDoc.Add(Option);
            }
            ViewBag.Doctors = selectDoc;

            return View(p1);
        }
        [HttpPost]
        public ActionResult EditProfile(Patient p)
        {
            this.repo.Update(p);
            if(ModelState.IsValid)
            {
                this.repo.Update(p);
                return RedirectToAction("DashBoard");

            }
            
            return View(p);
        }

        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction ("Login");

        }

        [HttpGet]
        public ActionResult Up()
        {
            /*
            Patient p = new Patient();
            Patient P1 = this.repo.GetLogin(p);
            Session["PATIENTP"] = P1.Id;
            */
            PatientRepository prepo = new PatientRepository();
            /*
            List<SelectListItem> selectPatient = new List<SelectListItem>();

            foreach (Patient p in prepo.GetAll())
            {
                SelectListItem Option = new SelectListItem();
                Option.Text = p.Name;
                Option.Value = p.Id.ToString();
                selectPatient.Add(Option);
            }
             */

            ViewBag.Patients = this.Session["PATIENT"];

            return View();
        }


        [HttpPost]

        public ActionResult Up(Image img)
        {
            string fileName = Path.GetFileNameWithoutExtension(img.ImageFile.FileName);
            string extension = Path.GetExtension(img.ImageFile.FileName);
            fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
            img.Path = "~/Image/" + fileName;
            fileName = Path.Combine(Server.MapPath("~/Image/"), fileName);
            img.ImageFile.SaveAs(fileName);

            this.context.Images.Add(img);
            this.context.SaveChanges();

            ModelState.Clear();
            /*

            DoctorRepository doctorRepo = new DoctorRepository();
            List<SelectListItem> selectDoc = new List<SelectListItem>();

            PatientRepository prepo = new PatientRepository();
            List<SelectListItem> selectPatient = new List<SelectListItem>();

            foreach (Patient p in prepo.GetAll())
            {
                SelectListItem Option = new SelectListItem();
                Option.Text = p.Name;
                Option.Value = p.Id.ToString();
                selectPatient.Add(Option);
            }
             */
            ViewBag.Patients = this.Session["PATIENT"];
             
            return View();
        }

        [HttpGet]
        public ActionResult GetPrescritpion()
        {
            int id = Convert.ToInt32(this.Session["PATIENT"]);
            List<Image> imglist = this.context.Images.Where(x => x.PatientId == id).ToList();


            return View(imglist);
        }
       

    

    }
}
