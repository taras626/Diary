using Microsoft.EntityFrameworkCore;
using NewDiary.Data.Abstract;
using NewDiary.Model;

namespace NewDiary.Data.EntityFramework
{
    public class EFComputerRepository : IComputerRepository
    {
        private readonly DataContext context;
        public EFComputerRepository(DataContext context) => this.context = context;   

        public Computer? GetItemById(int id)
        {
            return context.Computers.FirstOrDefault(i => i.Id == id);
        }

        public IQueryable<Computer> GetItems()
        {
            return context.Computers;
        }

        public IQueryable<Computer> GetComputersFromAuditory(Auditorium auditorium) 
        {
            return context.Computers.Where(i => i.Auditorium.Id == auditorium.Id);
        }
        
        public void Delete(ICollection<Computer> items)
        {
            foreach (Computer item in items) 
            {
                context.Computers.Remove(item);
            }
            context.SaveChanges();
        }

        public void SaveChanges(ICollection<Computer> items)
        {
            foreach (Computer item in items)
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
