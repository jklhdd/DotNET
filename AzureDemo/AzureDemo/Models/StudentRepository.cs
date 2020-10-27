using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace AzureDemo.Models
{
    public class StudentRepository
    {
        private string connString = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
        public void Insert(Student student)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                SqlCommand command = new SqlCommand();
                command.Connection = conn;
                command.CommandText = "Insert Students Values (@Name,@Address)";
                command.Parameters.AddWithValue("@Name", student.Name);
                command.Parameters.AddWithValue("@Address", student.Address);

                conn.Open();
                command.ExecuteNonQuery();
            }
        }

        public List<Student> GetAllStudent()
        {
            var students = new List<Student>();
            using (SqlConnection conn = new SqlConnection(connString))
            {
                SqlCommand command = new SqlCommand();
                command.Connection = conn;
                command.CommandText = "Select * from Students";

                conn.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            students.Add(new Student()
                            {
                                Id = reader.GetInt32(0),
                                Name = reader["Name"].ToString(),
                                Address = reader["Address"].ToString()
                            });
                        }
                    }
                }
            }
            return students;
        }

        public Student GetStudent(int id)
        {
            Student student = new Student();
            using (SqlConnection conn = new SqlConnection(connString))
            {
                SqlCommand command = new SqlCommand();
                command.Connection = conn;
                command.CommandText = "Select * from Students Where Id = @Id";
                command.Parameters.AddWithValue("@Id", id);

                conn.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            student = new Student()
                            {
                                Id = reader.GetInt32(0),
                                Name = reader["Name"].ToString(),
                                Address = reader["Address"].ToString()
                            };
                        }
                    }

                }
            }
            return student;
        }
    }
}