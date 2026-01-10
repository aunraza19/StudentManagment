using System.Collections.Generic;
using System.IO;
using System.Web.Script.Serialization;

namespace WindowsFormsApp1VPL
{
    public static class StudentRepository
    {
        private static string filePath = "students.json";
        private static JavaScriptSerializer serializer = new JavaScriptSerializer();

        public static List<Student> Load()
        {
            if (!File.Exists(filePath))
                return new List<Student>();

            string json = File.ReadAllText(filePath);
            return serializer.Deserialize<List<Student>>(json);
        }

        public static void Save(List<Student> students)
        {
            string json = serializer.Serialize(students);
            File.WriteAllText(filePath, json);
        }
    }
}
