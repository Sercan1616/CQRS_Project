using Microsoft.EntityFrameworkCore;

namespace CQRS_Project.Data
{
    public class StudentContext : DbContext
    {
        public StudentContext(DbContextOptions<StudentContext> options) : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().HasData(new Student[]
            {
                 new Student() {Name="Sercan",Age=0,Surname="Tokyürek",Id=1},
                 new Student() {Name="Nesrin",Age=1,Surname="Tokyürek",Id=2},
                 new Student() {Name="Zeki",Age=1,Surname="Tokyürek",Id=3},
                 new Student() {Name="Solmaz",Age=1,Surname="Tokyürek",Id=4}
            });
            base.OnModelCreating(modelBuilder);
        }
    }
}
