using Microsoft.EntityFrameworkCore;
using NewDiary.Model;

namespace NewDiary.Data.Abstract
{
    public interface IDiaryEntryRepository
    {
        public DiaryEntry? GetItemById(int id);
        public IQueryable<DiaryEntry> GetItemsByEmployee(Employee employee);
        public IQueryable<DiaryEntry> GetItemsByDepartment(Department department);
        public IQueryable<DiaryEntry> GetItemsByDay(DateTime dayOfWork);
        public IQueryable<DiaryEntry> GetItemsByMonth(DateTime monthOfWork);
        public IQueryable<DiaryEntry> GetItemsByYear(int year);
        public IQueryable<DiaryEntry> GetItemsBetweenDays(DateTime beginDay, DateTime endDay);
        public void Delete(ICollection<DiaryEntry> items);
        public void SaveChanges(ICollection<DiaryEntry> items);
    }
}
