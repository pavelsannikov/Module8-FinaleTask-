using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
namespace FinalTask
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"D:\Downloads\Students.dat";
            string result_path = @"C:\Users\pavel\Desktop\Students\";
            if (!Directory.Exists(result_path))
            {
                Directory.CreateDirectory(result_path);
            }
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                Student[] Student = (Student[])formatter.Deserialize(fs);
                foreach (var student in Student)
                {
                    using (StreamWriter student_file = new StreamWriter(String.Concat(result_path, student.Group,".txt"), true))
                    {
                        string st = String.Concat(student.Name, "\t", student.DateOfBirth);
                        student_file.WriteLine(st);
                        fs.Close();
                    }
                }
            }
            Console.WriteLine("Файлы созданы");
        }
    }
    [Serializable]
    class Student
    {
        public string Name { get; set; }
        public string Group { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}