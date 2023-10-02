using Microsoft.EntityFrameworkCore;
using NewDiary.Data.Abstract;
using NewDiary.Model;

namespace NewDiary.Data.EntityFramework
{
    public class EFAuditoriumRepository : IAuditoriumRepository
    {
        private readonly DataContext context;

        public EFAuditoriumRepository(DataContext context) => this.context = context;

        public Auditorium? GetItemById(int id)
        {
            return context.Auditorias.FirstOrDefault(i => i.IdAuditorium == id);
        }

        public IQueryable<Auditorium> GetItems()
        {
            return context.Auditorias;
        }

        public void Delete(ICollection<Auditorium> items)
        {
            foreach (Auditorium item in items) 
            {
                context.Auditorias.Remove(item);
            }
            context.SaveChanges();
        }

        public void SaveChanges(ICollection<Auditorium> items)
        {
            foreach (Auditorium item in items)
            {
                if (item.IdAuditorium == default)
                    context.Entry(item).State = EntityState.Added;
                else
                    context.Entry(item).State = EntityState.Modified;
            }
            context.SaveChanges();
        }
    }
}
