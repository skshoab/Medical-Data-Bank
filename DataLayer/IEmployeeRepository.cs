﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public interface IEmployeeRepository
    {
        List<Employee> GetAll();
        Employee Get(int id);
        int Insert(Employee emp);
        int Update(Employee emp);
        int Delete(int id);
    }
}
