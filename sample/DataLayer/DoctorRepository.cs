using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class DoctorRepository : IDoctorRepository
    {
        private DataContext context;

        public DoctorRepository()
        {
            this.context = new DataContext();
        }

        public List<Doctor> GetAll()
        {
            return this.context.Doctors.ToList();
        }

        public Doctor Get(int id)
        {
            return this.context.Doctors.SingleOrDefault(d => d.Id == id);
        }

        public Doctor GetLogin(Doctor d)
        {

            return this.context.Doctors.SingleOrDefault(e => e.email == d.email && e.password == d.password);
        }

        public int Insert(Doctor dept)
        {
            this.context.Doctors.Add(dept);
            return this.context.SaveChanges();
        }

        public int Update(Doctor dept)
        {
            Doctor deptToUpdate = this.context.Doctors.SingleOrDefault(d => d.Id == dept.Id);
            deptToUpdate.Name = dept.Name;
            deptToUpdate.Phone = dept.Phone;

            return this.context.SaveChanges();
        }

        public int Delete(int id)
        {
            Doctor deptToDelete = this.context.Doctors.SingleOrDefault(d => d.Id == id);
            this.context.Doctors.Remove(deptToDelete);
            return this.context.SaveChanges();
        }
    }
}
