using InterviewTestRun.Models;
using Microsoft.EntityFrameworkCore;

namespace InterviewTestRun.testDbContext
{
    public class InterviewDbContext : DbContext
    {
        public InterviewDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Student> Student { get; set; }
    }
}
