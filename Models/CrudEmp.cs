using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_RNWA.Models
{
    public class CrudEmp
    {

        public int employeeNumber { get; set; }
        public string lastName { get; set; }
        public string firstName { get; set; }
        public string extension { get; set; }
        public string email { get; set; }
        public string officeCode { get; set; }
        public int reportsTo { get; set; }
        public string jobTitle { get; set; }

    }
}