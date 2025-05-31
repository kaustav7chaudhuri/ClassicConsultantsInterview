using InterviewTestRunMVC.AppDbContext;
using InterviewTestRunMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace InterviewTestRunMVC.Controllers
{
    public class InterviewController : Controller
    {
        public readonly TestDbContext db;

        public InterviewController(TestDbContext db)
        {
            this.db = db;
        }
        [HttpGet]
        public IActionResult GetAllStudents()
        {
            IEnumerable<Student> obj = db.Student;            
            return View(obj);
        }
        [HttpGet]
        public IActionResult CreateStudent()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateStudent(Student studentData)
        {
            if(ModelState.IsValid && studentData is not null)
            {
                Guid rollnumber = Guid.NewGuid();
                studentData.RollNumber = rollnumber.ToString();
                db.Student.Add(studentData);
                db.SaveChanges();
                return RedirectToAction("GetAllStudents", "Interview");
            }
            return View();
        }
        public IActionResult UpdateStudent(int? id)
        {
            if(id is not null && id is 0)
            {
                return NotFound($"No Id by {id} is present");
            }
            var user = db.Student.FirstOrDefault(x => x.StudentID == id);
            if(user is null)
            {
                return NotFound($"student with {id} doesnot exists");
            }
            return View(user);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateStudent(Student data)
        {
            if(data is not null && ModelState.IsValid)
            {
                db.Student.Update(data);
                db.SaveChanges();
                return RedirectToAction("GetAllStudents", "Interview");
            }
            return View(data);
        }

        public IActionResult DeleteStudent(int? id)
        {
            if (id is not null && id is 0)
            {
                return NotFound($"No Id by {id} is present");
            }
            var user = db.Student.FirstOrDefault(x => x.StudentID == id);
            if (user is null)
            {
                return NotFound($"student with student id {id} doesnot exists");
            }
            return View(user);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteStudent(int id)
        {
            var user = db.Student.Find(id);
            if(user is not null)
            {
                db.Student.Remove(user);
                db.SaveChanges();
                return RedirectToAction("GetAllStudents", "Interview");
            }
            return NotFound($"Student with StudentID:'{id}' not found");
        }
    }
}
