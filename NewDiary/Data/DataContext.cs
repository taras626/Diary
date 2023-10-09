using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.EntityFrameworkCore;
using NewDiary.Model;

namespace NewDiary.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Auditorium> Auditorias {  get; set; }
        public DbSet<Computer> Computers { get; set; }
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

            modelBuilder.Entity<Auditorium>().HasKey(a => a.Id);
            modelBuilder.Entity<GroupWork>().HasKey(gw => gw.Id);
            modelBuilder.Entity<Computer>().HasKey(c => c.Id);
            modelBuilder.Entity<Work>().HasKey(w => w.Id);
            modelBuilder.Entity<Employee>().HasKey(e => e.Id);
            modelBuilder.Entity<Department>().HasKey(d => d.Id);
            modelBuilder.Entity<SubGroupWork>().HasKey(sgw => sgw.Id);
            modelBuilder.Entity<ElementOfWork>().HasKey(eow => eow.Id);
        }
    }
}
