using Microsoft.EntityFrameworkCore;
using NewDiary.Data.Abstract;
using NewDiary.Model;
using System;

namespace NewDiary.Data.EntityFramework
{
    public class EFWorkRepository : IWorkRepository
    {
        private readonly DataContext context;

        public EFWorkRepository(DataContext context) => this.context = context;

        public Work? GetItemById(int id)
        {
            return context.Works.FirstOrDefault(i => i.IdWork == id);
        }

        public void Delete(ICollection<Work> items)
        {
            foreach (Work item in items)
                context.Works.Remove(item);

            context.SaveChanges();
        }
        
        public void SaveChanges(ICollection<Work> items)
        {
            foreach (Work item in items) 
            {
                if (item.IdWork == default)
                    context.Entry(item).State = EntityState.Added;
                else
                    context.Entry(item).State = EntityState.Modified;
            }

            context.SaveChanges();
        }

        public IQueryable<Work> GetItemsByEmployee(Employee employee)
        {
            return context.Works.Where(de => de.Employee.Equals(employee));
        }

        public IQueryable<Work> GetItemsByDepartment(Department department)
        {
            return context.Works.Where(de => de.Employee.Department.Equals(department));
        }

        public IQueryable<Work> GetItemsByYear(int year)
        {
            return context.Works.Where(de => de.DateOfCompletion.Year == year);
        }

        public IQueryable<Work> GetItemsByMonth(DateTime monthOfWork)
        {
            return context.Works
                .Where(de => de.DateOfCompletion.Month == monthOfWork.Month)
                .Where(de => de.DateOfCompletion.Year == monthOfWork.Year);
        }

        public IQueryable<Work> GetItemsByDay(DateTime dayOfWork)
        {
            return context.Works
                .Where(de => de.DateOfCompletion.Day == dayOfWork.Day)
                .Where(de => de.DateOfCompletion.Month == dayOfWork.Month)
                .Where(de => de.DateOfCompletion.Year == dayOfWork.Year);
        }

        public IQueryable<Work> GetItemsBetweenDays(DateTime beginDay, DateTime endDay)
        {
            return context.Works
                .Where(de => de.DateOfCompletion >= beginDay && de.DateOfCompletion <= endDay);
        }
    }
}
