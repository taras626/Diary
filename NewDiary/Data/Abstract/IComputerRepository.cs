using Microsoft.EntityFrameworkCore;
using NewDiary.Model;

namespace NewDiary.Data.Abstract
{
    public interface IComputerRepository
    {
        public Computer? GetItemById(int id);
        public IQueryable<Computer> GetItems();
        public void Delete(ICollection<Computer> items);
        public void SaveChanges(ICollection<Computer> items);
    }
}
