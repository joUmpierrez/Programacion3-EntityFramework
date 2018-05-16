using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prueba01_EntityFramework
{
    public class Program
    {
        static void Main(string[] args)
        {
            // -----------------------------------------------------> PARTE 01 <-----------------------------------------------------
            // Alta de Estudiante 
            UniversityContext db = new UniversityContext();

            Student student01 = new Student();
            student01.name = "Joaquin";
            student01.age = 23;
            db.students.Add(student01);
            db.SaveChanges();

            Student student02 = new Student();
            student02.name = "Camila";
            student02.age = 22;
            db.students.Add(student02);
            db.SaveChanges();

            Student student03 = new Student();
            student03.name = "Victoria";
            student03.age = 11;
            db.students.Add(student03);
            db.SaveChanges();

            // Obtener Estudiantes
            IEnumerable<Student> students = from Student s in db.students select s; // LINQ
            foreach (Student theS in students)
            {
                Console.WriteLine($"{theS.id} ---> {theS.name}, {theS.age}");
            }

            // Modificar Datos de Estudiante
            Student searchedStudent = db.students.Find(1); // Con Find() se busca un objeto segun su PK
            if (searchedStudent != null)
            {
                searchedStudent.name = "Joaquin - Nombre Cambiado";
                db.SaveChanges();
            }

            // Eliminar unEstudiante
            searchedStudent = db.students.Find(3); // Con Find() se busca un objeto segun su PK
            if (searchedStudent != null)
            {
                db.students.Remove(searchedStudent);
                db.SaveChanges();
            }

            // -----------------------------------------------------> PARTE 02 <-----------------------------------------------------
            // Agregar Curso con Estudiantes
            Course course01 = new Course();
            course01.name = "Programming";
            if (course01.myStudents == null)
            {
                course01.myStudents = new List<Student>();
                course01.myStudents.Add(db.students.Find(1));
                course01.myStudents.Add(db.students.Find(2));
            }
            db.courses.Add(course01);
            db.SaveChanges();

            // Obtener Cursos y los Estudiantes en ellos
            IEnumerable<Course> courses = from Course c in db.courses select c;
            foreach (Course theC in courses)
            {
                Console.WriteLine("");
                Console.WriteLine($"Nombre: {theC.name}");
                if (theC.myStudents != null && theC.myStudents.Count > 0)
                {
                    Console.WriteLine("---> Estudiantes <---");
                    foreach (Student theS in theC.myStudents)
                    {
                        Console.WriteLine($"{theS.id} ---> {theS.name}, {theS.age}");
                    }
                }
            }
        }
    }
}
