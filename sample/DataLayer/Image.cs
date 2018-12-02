using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using System.Web;

namespace DataLayer
{
    public class Image
    {
        public int Id { get; set; }
        public string Title { get; set; }
        
        [DisplayName("Upload File")]
        public string Path { get; set; }
        [NotMapped]
        public HttpPostedFileBase ImageFile { get; set; }


        
        public int PatientId{ get; set; }

        [ForeignKey("PatientId")]
        public Patient Patient { get; set; }
    }
}
