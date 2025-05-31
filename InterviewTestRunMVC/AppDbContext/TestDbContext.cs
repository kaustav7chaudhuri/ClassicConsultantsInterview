using InterviewTestRunMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace InterviewTestRunMVC.AppDbContext
{
    public class TestDbContext : DbContext
    {
        public TestDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Student> Student { get; set; }
    }
    
}
