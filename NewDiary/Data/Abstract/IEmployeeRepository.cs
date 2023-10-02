using Microsoft.EntityFrameworkCore;
using NewDiary.Model;

namespace NewDiary.Data.Abstract
{
    public interface IEmployeeRepository
    {
        public Employee? GetItemById(int id);
        public IQueryable<Employee> GetItems();
        public void Delete(ICollection<Employee> items);
        public void SaveChanges(ICollection<Employee> items);
    }
}
