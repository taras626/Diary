using Microsoft.EntityFrameworkCore;
using NewDiary.Model;

namespace NewDiary.Data.Abstract
{
    public interface IDepartmentRepository
    {
        public Department? GetItemById(int id);
        public IQueryable<Department> GetItems();
        public void Delete(ICollection<Department> items);
        public void SaveChanges(ICollection<Department> items);
    }
}
