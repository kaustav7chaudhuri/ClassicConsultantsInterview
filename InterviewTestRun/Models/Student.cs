namespace InterviewTestRun.Models
{
    public class Student
    {
        public int StudentID { get; set; }
        public string StudentName { get; set; } = string.Empty;
        public string RollNumber { get; set; } = string.Empty;
        public string Department { get; set; } = string.Empty;
        public string CollegeName { get; set; } = string.Empty;
        public StudentType StudentType { get; set; }
    }
    public enum StudentType
    {
        Engineering,Medical
    }
}
