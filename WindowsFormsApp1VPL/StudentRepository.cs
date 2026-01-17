using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;

namespace WindowsFormsApp1VPL
{
    public static class StudentRepository
    {
        private static readonly string FilePath = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
            "StudentManagementSystem",
            "students.json"
        );

        private static readonly DataContractJsonSerializer Serializer = 
            new DataContractJsonSerializer(typeof(List<Student>));

        public static List<Student> Load()
        {
            try
            {
                if (!File.Exists(FilePath))
                {
                    EnsureDirectoryExists();
                    return new List<Student>();
                }

                using (FileStream stream = new FileStream(FilePath, FileMode.Open, FileAccess.Read))
                {
                    var students = (List<Student>)Serializer.ReadObject(stream);
                    return students ?? new List<Student>();
                }
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Failed to load student data: {ex.Message}", ex);
            }
        }

        public static void Save(List<Student> students)
        {
            try
            {
                if (students == null)
                {
                    throw new ArgumentNullException(nameof(students));
                }

                EnsureDirectoryExists();

                using (FileStream stream = new FileStream(FilePath, FileMode.Create, FileAccess.Write))
                {
                    Serializer.WriteObject(stream, students);
                }
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Failed to save student data: {ex.Message}", ex);
            }
        }

        private static void EnsureDirectoryExists()
        {
            string directory = Path.GetDirectoryName(FilePath);
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
        }

        public static string GetDataFilePath()
        {
            return FilePath;
        }
    }
}
