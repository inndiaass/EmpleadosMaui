using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text;

namespace PracticaMaui.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public List<Employee> Employees { get; set; }
    }
}
