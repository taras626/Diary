using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.EntityFrameworkCore;
using NewDiary.Model;

namespace NewDiary.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Auditorium> Auditorias {  get; set; }
        public DbSet<Computer> Computers { get; set; }
        public DbSet<DiaryEntry> DiaryEntries { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }  
        public DbSet<GroupWork> GroupWorks { get; set; }
        public DbSet<Work> Works { get; set; }
        public DbSet<SubGroupWork> SubGroupWorks { get; set; }
        public DbSet<ElementOfWork> ElementsOfWorks { get; set; }
            
        public DataContext(DbContextOptions<DataContext> options) : base (options) 
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Auditorium>().HasKey(a => a.IdAuditorium);
            modelBuilder.Entity<GroupWork>().HasKey(gw => gw.IdGroupWork);
            modelBuilder.Entity<Computer>().HasKey(c => c.IdComputer);
            modelBuilder.Entity<Work>().HasKey(w => w.IdWork);
            modelBuilder.Entity<DiaryEntry>().HasKey(de => de.IdDiaryEntry);
            modelBuilder.Entity<Employee>().HasKey(e => e.IdEmployee);
            modelBuilder.Entity<Department>().HasKey(d => d.IdDepartment);
            modelBuilder.Entity<SubGroupWork>().HasKey(sgw => sgw.IdSubGroupWork);
            modelBuilder.Entity<ElementOfWork>().HasKey(eow => eow.IdElementOfWork);

            ////Many-1
            //modelBuilder.Entity<Auditorium>().HasMany(a => a.Computers).WithOne(c => c.Auditorium);
            //modelBuilder.Entity<Employee>().HasMany(de => de.DiaryEntries).WithOne(e => e.Employee);
            //modelBuilder.Entity<Department>().HasMany(e => e.EmployeeOfDepartment).WithOne(d => d.Department);
            //modelBuilder.Entity<>()

            ////1-1
            modelBuilder.Entity<Work>().HasOne(w => w.Entry).WithOne(gw => gw.ObjOfWork);
        }
    }
}
