using System;

namespace WindowsFormsApp1VPL
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Marks { get; set; }

        public Student() { }

        public Student(int id, string name, double marks)
        {
            Id = id;
            Name = name;
            Marks = marks;
        }

        public bool IsValid(out string errorMessage)
        {
            errorMessage = string.Empty;

            if (Id <= 0)
            {
                errorMessage = "ID must be a positive number.";
                return false;
            }

            if (string.IsNullOrWhiteSpace(Name))
            {
                errorMessage = "Name cannot be empty.";
                return false;
            }

            if (Marks < 0 || Marks > 100)
            {
                errorMessage = "Marks must be between 0 and 100.";
                return false;
            }

            return true;
        }

        public override string ToString()
        {
            return $"ID: {Id}, Name: {Name}, Marks: {Marks}";
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            Student other = (Student)obj;
            return Id == other.Id;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}
