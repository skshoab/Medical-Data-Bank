using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace DataLayer
{
    public class Doctor
    {
        public int Id { get; set; }
        public string password { get; set; }

        [Required, MaxLength(50)]
        public string Name { get; set; }

        [Required, MaxLength(50)]
        public string email { get; set; }
        public string Phone { get; set; }
        public string specialist { get; set; }
        public string prescription { get; set; }

        public int? PateintId { get; set; }
        [ForeignKey("PatientId")]
        public List<Patient> Patients { get; set; }
    }
}
