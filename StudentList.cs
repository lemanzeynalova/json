using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class StudentList
    {
        private List<Student> students;

        public StudentList()
        {
            students = new List<Student>();
        }

        public void AddStudent(Student student) => students.Add(student);

        public void RemoveStudent(string code)
        {
            Student studentToRemove = students.FirstOrDefault(s => s.Code == code);
            if (studentToRemove != null)
            {
                students.Remove(studentToRemove);
            }
        }

        public void EditStudent(string code, Student updatedStudent)
        {
            Student existingStudent = students.FirstOrDefault(s => s.Code == code);
            if (existingStudent != null)
            {
                existingStudent.Name = updatedStudent.Name;
                existingStudent.Surname = updatedStudent.Surname;
                existingStudent.Code = updatedStudent.Code;
            }
        }

        public void SerializeToJson(string filePath)
        {
            string json = JsonConvert.SerializeObject(students);
            File.WriteAllText(filePath, json);
        }

        public void DeserializeFromJson(string filePath)
        {
            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);
                students = JsonConvert.DeserializeObject<List<Student>>(json);
            }
        }

        public void PrintStudents()
        {
            foreach (var student in students)
            {
                Console.WriteLine($"Name: {student.Name}, Surname: {student.Surname}, Code: {student.Code}");
            }
        }
    }
}
