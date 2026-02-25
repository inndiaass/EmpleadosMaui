using System;
using System.Collections.Generic;
using System.Text;

namespace PracticaMaui.Models
{
    public class Employee
    {
        public int? Id { get; set; }

        public string? Name { get; set; }
        public string? LastName { get; set; }
        public int? Edad { get; set; }
        public string? Gmail { get; set; }
        public string? ImageUrl { get; set; }

        public int DepartmentId { get; set; }

        public Department? Department { get; set; }
    }
}

