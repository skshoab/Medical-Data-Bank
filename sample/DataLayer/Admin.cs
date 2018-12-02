using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class Admin
    {
        public int id { get; set; }

        public string userName { get; set; }

        [DataType(DataType.Password)]
        public string password { get; set; }
    }
}
