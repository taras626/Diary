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
            return context.Works.FirstOrDefault(i => i.Id == id);
        }//Y

        public void Delete(ICollection<Work> items)
        {
            foreach (Work item in items)
                context.Works.Remove(item);

            context.SaveChanges();
        }//Y
        
        public void SaveChanges(ICollection<Work> items)
        {
            foreach (Work item in items) 
            {
                if (item.Id == default)
                    context.Entry(item).State = EntityState.Added;
                else
                    context.Entry(item).State = EntityState.Modified;
            }

            context.SaveChanges();
        }//Y

        public IQueryable<Work> GetItemsByEmployee(Employee employee, DateTime beginDay = default, DateTime endDay = default)
        {
            if(beginDay == default && endDay == default)
                return context.Works.Where(w => w.Employee.Equals(employee));

            if (beginDay == default)
                return context.Works.Where(w => w.Employee.Equals(employee)).Where(w => w.DateOfCompletion <= endDay);

            if (endDay == default)
                return context.Works.Where(w => w.Employee.Equals(employee)).Where(w => w.DateOfCompletion == beginDay);

            return context.Works.Where(w => w.Employee.Equals(employee)).Where(w => w.DateOfCompletion <= endDay && w.DateOfCompletion >= beginDay);
        }//Y

        public IQueryable<Work> GetItemsByDepartment(Department department, DateTime beginDay = default, DateTime endDay = default)
        {
            if (beginDay == default && endDay == default)
                return context.Works.Where(w => w.Employee.Department.Equals(department));

            if (beginDay == default)
                return context.Works.Where(w => w.Employee.Department.Equals(department)).Where(w => w.DateOfCompletion <= endDay);

            if (endDay == default)
                return context.Works.Where(w => w.Employee.Department.Equals(department)).Where(w => w.DateOfCompletion == beginDay);

            return context.Works.Where(w => w.Employee.Department.Equals(department)).Where(w => w.DateOfCompletion <= endDay && w.DateOfCompletion >= beginDay);
        }//Y

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
