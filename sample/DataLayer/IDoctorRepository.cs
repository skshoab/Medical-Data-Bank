using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public interface IDoctorRepository
    {
        List<Doctor> GetAll();
        Doctor Get(int id);
        int Insert(Doctor d);
        int Update(Doctor d);
        int Delete(int id);
    }
}
