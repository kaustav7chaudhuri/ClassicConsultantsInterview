using InterviewTestRun.Models;
using InterviewTestRun.testDbContext;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InterviewTestRun.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InterviewController : ControllerBase
    {
        public readonly InterviewDbContext db;

        public InterviewController(InterviewDbContext db)
        {
            this.db = db;
        }

        [HttpGet]
        public IActionResult GetStudents()
        {
            var list = db.Student.ToList();
            return Ok(list);
        }
        [HttpPost]
        public async Task<IActionResult> InsertStudent([FromQuery] Student Student)
        {
            if (ModelState.IsValid && Student is not null)
            {
                Guid rollNumber = Guid.NewGuid();
                Student.RollNumber = rollNumber.ToString();
                await db.Student.AddAsync(Student);
                await db.SaveChangesAsync();
                return Ok("Successfully Inserted");
            }
            return BadRequest("Failed");
        }
        [HttpPut]
        [Route("Update")]
        public IActionResult UpdateStudent([FromQuery] int id, [FromBody] Student student)
        {
            var UserExists = db.Student.Find(id);
            if(UserExists is not null)
            {
                UserExists.StudentName = student.StudentName;
                UserExists.CollegeName = student.CollegeName;
                UserExists.StudentType = student.StudentType;
                UserExists.Department = student.Department;
                db.SaveChangesAsync();
                return Ok(UserExists);
            }
            return NotFound();
        }
        [HttpDelete]
        public IActionResult DeleteStudent([FromQuery] int id)
        {
            var UserExists = db.Student.Find(id);
            if(UserExists is not null)
            {
                db.Student.Remove(UserExists);
                db.SaveChanges();
                return Ok("Deleted");
            }
            return BadRequest("Failed");
        }
    }
}
