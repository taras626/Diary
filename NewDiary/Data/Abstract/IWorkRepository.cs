using Microsoft.EntityFrameworkCore;
using NewDiary.Model;

namespace NewDiary.Data.Abstract
{
    public interface IWorkRepository
    {
        public Work? GetItemById(int id);
        public IQueryable<Work> GetItemsByEmployee(Employee employee, DateTime beginDay = default, DateTime endDay = default);
        public IQueryable<Work> GetItemsByDepartment(Department department, DateTime beginDay = default, DateTime endDay = default);
        public IQueryable<Work> GetItemsByDay(DateTime dayOfWork);
        public IQueryable<Work> GetItemsByMonth(DateTime monthOfWork);
        public IQueryable<Work> GetItemsByYear(int year);
        public IQueryable<Work> GetItemsBetweenDays(DateTime beginDay, DateTime endDay);
        public void Delete(ICollection<Work> items);
        public void SaveChanges(ICollection<Work> items);
    }
}
