using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManager.Domain.Models
{
    public class Employee
    {
        public int id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string department { get; set; }
    }

    public class Employees : List<Employee> { }
}
