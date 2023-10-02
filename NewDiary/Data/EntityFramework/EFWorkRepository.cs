using Microsoft.EntityFrameworkCore;
using NewDiary.Data.Abstract;
using NewDiary.Model;

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

        public IQueryable<Work> GetItems()
        {
            return context.Works;
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
    }
}
