using Microsoft.EntityFrameworkCore;
using NewDiary.Data.Abstract;
using NewDiary.Model;

namespace NewDiary.Data.EntityFramework
{
    public class EFEmployeeRepository : IEmployeeRepository
    {
        private readonly DataContext context;

        public EFEmployeeRepository(DataContext context) => this.context = context;
        public Employee? GetItemById(int id)
        {
            return context.Employees.FirstOrDefault(e => e.Id == id);   
        }

        public IQueryable<Employee> GetItems()
        {
            return context.Employees;
        }

        public void Delete(ICollection<Employee> items)
        {
            foreach (var item in items)
                context.Employees.Remove(item);
            context.SaveChanges();
        }

        public void SaveChanges(ICollection<Employee> items)
        {
            foreach (var item in items)
            {
                if (item.Id == default)
                    context.Entry(item).State = EntityState.Added;
                else
                    context.Entry(item).State = EntityState.Modified;
            }

            context.SaveChanges();
        }
    }
}
