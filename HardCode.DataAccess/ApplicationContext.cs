using HardCode.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace HardCode.DataAccess
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Department> Departments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Department>().HasData(
                new Department() { Id = 1, Name = "IT", Description = "IT Department" });

            modelBuilder.Entity<Department>().HasData(
                new Department() { Id = 2, Name = "HR", Description = "HR Department" });

            modelBuilder.Entity<Instructor>().HasData(
                new Instructor() { Id = 1, Name = "Mahmoud Sami", BirthDate = new System.DateTime(1998,11,22), DepartmentID = 1  });

            modelBuilder.Entity<Instructor>().HasData(
                new Instructor() { Id = 2, Name = "AbdelRahman Hindi", BirthDate = new System.DateTime(1997, 06, 22), DepartmentID = 2 });


        }
    }
}
