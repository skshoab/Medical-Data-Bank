using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public interface IPatientRepository
    {
        List<Patient> GetAll();
        Patient Get(int id);
        int Insert(Patient p);
        int Update(Patient p);
        int Delete(int id);
    }
}
