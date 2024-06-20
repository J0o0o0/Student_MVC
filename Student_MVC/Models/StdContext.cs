using Microsoft.EntityFrameworkCore;
using System;
namespace Student_MVC.Models
{
    public class StdContext : DbContext
    {


       

        public StdContext(DbContextOptions<StdContext> options):base(options) 
        {
            
        }
       
       
        public DbSet<Student> Students { get; set; }
        public DbSet<Department> Departments { get; set; }
    }
}
