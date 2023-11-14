namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StudentList studentList = new StudentList();

           
            Student student1 = new Student { Name = "Deniz", Surname = "Imanov", Code = "2002" };
            studentList.AddStudent(student1);

            
            studentList.SerializeToJson("students.json");

           
            studentList.RemoveStudent("2002");

           
            studentList.DeserializeFromJson("students.json");

           
            studentList.PrintStudents();
        }
    }
}