using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class AdminRepository
    {
        private DataContext context;

        public AdminRepository()
        {
            this.context = new DataContext();
        }

        public Admin GetLogin(Admin a)
        {

            return this.context.Admins.SingleOrDefault(e => e.userName == a.userName && e.password == a.password);
        }

        public List<Patient> GetAll()
        {
            return this.context.Patients.ToList();
        }
    }
}
