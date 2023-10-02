using Microsoft.EntityFrameworkCore;
using NewDiary.Data.Abstract;
using NewDiary.Model;

namespace NewDiary.Data.EntityFramework
{
    public class EFDepartmentRepository : IDepartmentRepository
    {
        private readonly DataContext context;

        public EFDepartmentRepository(DataContext context) => this.context = context;

        public Department? GetItemById(int id)
        {
            return context.Departments.FirstOrDefault(d => d.IdDepartment == id);
        }

        public IQueryable<Department> GetItems()
        {
            return context.Departments;
        }

        public void Delete(ICollection<Department> items)
        {
            foreach (Department item in items)
                context.Departments.Remove(item);
            
            context.SaveChanges();
        }

        public void SaveChanges(ICollection<Department> items)
        {
            foreach (Department item in items)
            {
                if (item.IdDepartment == default)
                    context.Entry(item).State = EntityState.Added;
                else
                    context.Entry(item).State = EntityState.Modified;
            }

            context.SaveChanges();
        }
    }
}
