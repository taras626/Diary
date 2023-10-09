using Microsoft.EntityFrameworkCore;
using NewDiary.Data.Abstract;
using NewDiary.Model;

namespace NewDiary.Data.EntityFramework
{
    public class EFElementOfWorkRepository : IElementOfWorkRepository
    {
        private readonly DataContext context;
        public EFElementOfWorkRepository(DataContext context) => this.context = context;

        public ElementOfWork? GetItemById(int id)
        {
            return context.ElementsOfWorks.FirstOrDefault(i => i.Id == id);
        }

        public IQueryable<ElementOfWork> GetItems()
        {
            return context.ElementsOfWorks;
        }

        public void Delete(ICollection<ElementOfWork> items)
        {
            foreach (ElementOfWork item in items) 
                context.ElementsOfWorks.Remove(item);
            
            context.SaveChanges();
        }

        public void SaveChanges(ICollection<ElementOfWork> items)
        {
            foreach (ElementOfWork item in items)
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
