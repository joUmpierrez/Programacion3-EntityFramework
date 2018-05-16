using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prueba01_EntityFramework
{
    public class Course
    {
        public int id { get; set; }
        public string name { get; set; }
        public virtual List<Student> myStudents { get; set; }
    }
}
