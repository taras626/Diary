using Microsoft.EntityFrameworkCore;
using NewDiary.Data.Abstract;
using NewDiary.Model;

namespace NewDiary.Data.EntityFramework
{
    public class EFSubGroupWorkRepository : ISubGroupWorkRepository
    {
        private readonly DataContext context;
        public EFSubGroupWorkRepository(DataContext context) => this.context = context;

        public SubGroupWork? GetItemById(int id)
        {
            return context.SubGroupWorks.FirstOrDefault(i => i.IdSubGroupWork == id);
        }

        public IQueryable<SubGroupWork> GetItems()
        {
            return context.SubGroupWorks;
        }

        public void Delete(ICollection<SubGroupWork> items)
        {
            foreach (SubGroupWork item in items) 
                context.SubGroupWorks.Remove(item);
            
            context.SaveChanges();
        }

        public void SaveChanges(ICollection<SubGroupWork> items)
        {
            foreach (SubGroupWork item in items)
            {
                if (item.IdSubGroupWork == default)
                    context.Entry(item).State = EntityState.Added;
                else
                    context.Entry(item).State = EntityState.Modified;
            }

            context.SaveChanges();
        }
    }
}
