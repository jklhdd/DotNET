using ServiceReference1;
using System;

namespace ClientExam
{
    class Program
    {
        static void Main(string[] args)
        {
            IStudentService service = new StudentServiceClient();
            var students = service.GetAllStudentsAsync();
            foreach (var student in students)
            {
                Console.WriteLine($"Id: {student.Id}, Name: {student.Name}");
            }
            Console.ReadLine();
        }
    }
}
