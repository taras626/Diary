using Microsoft.EntityFrameworkCore;
using NewDiary.Data.Abstract;
using NewDiary.Model;
using System;

namespace NewDiary.Data.EntityFramework
{
    public class EFDiaryEntryRepository : IDiaryEntryRepository
    {
        private readonly DataContext context;

        public EFDiaryEntryRepository(DataContext context) => this.context = context;

        public DiaryEntry? GetItemById(int id)
        {
            return context.DiaryEntries.FirstOrDefault(i => i.IdDiaryEntry == id);
        }

        public void Delete(ICollection<DiaryEntry> items)
        {
            foreach (DiaryEntry item in items)
                context.DiaryEntries.Remove(item);

            context.SaveChanges();
        }
        
        public void SaveChanges(ICollection<DiaryEntry> items)
        {
            foreach (DiaryEntry item in items) 
            {
                if (item.IdDiaryEntry == default)
                    context.Entry(item).State = EntityState.Added;
                else
                    context.Entry(item).State = EntityState.Modified;
            }

            context.SaveChanges();
        }

        public IQueryable<DiaryEntry> GetItemsByEmployee(Employee employee)
        {
            return context.DiaryEntries.Where(de => de.Employee.Equals(employee));
        }

        public IQueryable<DiaryEntry> GetItemsByDepartment(Department department)
        {
            return context.DiaryEntries.Where(de => de.Employee.Department.Equals(department));
        }

        public IQueryable<DiaryEntry> GetItemsByYear(int year)
        {
            return context.DiaryEntries.Where(de => de.ObjOfWork.DateOfCompletion.Year == year);
        }

        public IQueryable<DiaryEntry> GetItemsByMonth(DateTime monthOfWork)
        {
            return context.DiaryEntries
                .Where(de => de.ObjOfWork.DateOfCompletion.Month == monthOfWork.Month)
                .Where(de => de.ObjOfWork.DateOfCompletion.Year == monthOfWork.Year);
        }

        public IQueryable<DiaryEntry> GetItemsByDay(DateTime dayOfWork)
        {
            return context.DiaryEntries
                .Where(de => de.ObjOfWork.DateOfCompletion.Day == dayOfWork.Day)
                .Where(de => de.ObjOfWork.DateOfCompletion.Month == dayOfWork.Month)
                .Where(de => de.ObjOfWork.DateOfCompletion.Year == dayOfWork.Year);
        }

        public IQueryable<DiaryEntry> GetItemsBetweenDays(DateTime beginDay, DateTime endDay)
        {
            return context.DiaryEntries
                .Where(de => de.ObjOfWork.DateOfCompletion >= beginDay && de.ObjOfWork.DateOfCompletion <= endDay);
        }
    }
}
