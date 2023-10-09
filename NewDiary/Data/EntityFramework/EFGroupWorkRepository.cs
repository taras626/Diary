using Microsoft.EntityFrameworkCore;
using NewDiary.Data.Abstract;
using NewDiary.Model;

namespace NewDiary.Data.EntityFramework
{
    public class EFGroupWorkRepository : IGroupWorkRepository
    {
        private readonly DataContext context;
        public EFGroupWorkRepository(DataContext context) => this.context = context;

        public GroupWork? GetItemById(int id)
        {
            return context.GroupWorks.FirstOrDefault(i => i.Id == id);
        }

        public IQueryable<GroupWork> GetItems()
        {
            return context.GroupWorks;
        }

        public void Delete(ICollection<GroupWork> items)
        {
            foreach (GroupWork item in items) 
                context.GroupWorks.Remove(item);
            
            context.SaveChanges();
        }

        public void SaveChanges(ICollection<GroupWork> items)
        {
            foreach (GroupWork item in items)
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
