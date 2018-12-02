using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace DataLayer
{
    public class Patient
    {
        public int Id { get; set; }
       

        [Required, MaxLength(50)]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Phone { get; set; }

        [Required]
        public int Age { get; set; }

        [Required]

        public string Gender { get; set; }

        [Required(ErrorMessage = "Must type Password")]

        [DataType(DataType.Password)]
        public string password { get; set; }
        public string Symptomps { get; set; }

        public int? DoctorId { get; set; }

        [ForeignKey("DoctorId")]
        public List<Doctor> Doctors { get; set; }
    }
}
