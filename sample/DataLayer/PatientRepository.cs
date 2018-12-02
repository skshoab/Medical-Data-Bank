using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class PatientRepository : IPatientRepository
    {
        private DataContext context;

        public PatientRepository() { this.context = new DataContext(); }

        public List<Patient> GetAll()
        {
            return this.context.Patients.ToList();
        }

        public Patient Get(int id)
        {
            return this.context.Patients.SingleOrDefault(e => e.Id == id);
        }
        public List<Patient> GetDoctor(int id)
        {
            List<Patient> PatientList = this.context.Patients.Where(e => e.DoctorId == id).ToList();
            return PatientList;
        }

        public Patient GetLogin(Patient p)
        {
            
            return this.context.Patients.SingleOrDefault(e => e.Email == p.Email && e.password == p.password);
        }


        public int Insert(Patient p)
        {
            this.context.Patients.Add(p);
            return this.context.SaveChanges();
        }

        public int Update(Patient p)
        {
            Patient empToUpdate = this.context.Patients.SingleOrDefault(e => e.Id == p.Id);
            empToUpdate.Name = p.Name;
            empToUpdate.Age = p.Age;
            empToUpdate.Email = p.Email;
            empToUpdate.Phone = p.Phone;
            empToUpdate.Symptomps = p.Symptomps;
            empToUpdate.password = p.password;
            empToUpdate.DoctorId = p.DoctorId;

            return this.context.SaveChanges();
        }

        public int Delete(int id)
        {
            Patient empToDelete = this.context.Patients.SingleOrDefault(e => e.Id == id);
            this.context.Patients.Remove(empToDelete);

            return this.context.SaveChanges();
        }
    }
}
