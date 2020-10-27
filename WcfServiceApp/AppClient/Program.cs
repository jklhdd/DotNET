using AppClient.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppClient
{
    public class Program
    {
        static void Main(string[] args)
        {
            IStudentService service = new StudentServiceClient();
            var students = service.GetStudents();
            foreach (var student in students)
            {
                Console.WriteLine($"Id: {student.Id}, Name: {student.FirstName}");
            }
            Console.ReadLine();
        }
    }
}
