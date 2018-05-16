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
            // Alta de Estudiante 
            UniversityContext db = new UniversityContext();

            Student student01 = new Student();
            student01.name = "Joaquin";
            student01.age = 23;
            db.Students.Add(student01);
            db.SaveChanges();

            Student student02 = new Student();
            student02.name = "Camila";
            student02.age = 22;
            db.Students.Add(student02);
            db.SaveChanges();

            db.Dispose();

            // Obtener Estudiantes
            UniversityContext otherDb = new UniversityContext();
            IEnumerable<Student> students = from Student s in otherDb.Students select s; // LINQ
            foreach (Student theS in students)
            {
                Console.WriteLine($"{theS.id} ---> {theS.name}, {theS.age}");
            }

            // Modificar Datos de Estudiante
            Student searchedStudent = otherDb.Students.Find(1); // Con Find() se busca un objeto segun su PK
            if (searchedStudent != null)
            {
                searchedStudent.name = "Nombre Cambiado";
                otherDb.SaveChanges();
            }

            // Eliminar unEstudiante
            searchedStudent = otherDb.Students.Find(2); // Con Find() se busca un objeto segun su PK
            if (searchedStudent != null)
            {
                otherDb.Students.Remove(searchedStudent);
                otherDb.SaveChanges();
            }
        }
    }
}
