using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoFinalMoviles.Models
{
    public class Student
    {
        public string NumberDocument { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public DateTime LastView { get; set; }
        public string Description { get; set; }
        public string Observation { get; set; }
    }
}
