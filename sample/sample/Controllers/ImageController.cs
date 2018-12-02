using DataLayer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace sample.Controllers
{
    public class ImageController : Controller
    {
        //
        // GET: /Image/

        private PatientRepository repo = new PatientRepository();
        private DataContext context = new DataContext();
        [HttpGet]
        public ActionResult Up()
        {
            /*
            Patient p = new Patient();
            Patient P1 = this.repo.GetLogin(p);
            Session["PATIENTP"] = P1.Id;
            */
            
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
            return View();
        }
          
    }
}
