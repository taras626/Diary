using Microsoft.EntityFrameworkCore;
using NewDiary.Model;

namespace NewDiary.Data.Abstract
{
    public interface IWorkRepository
    {
        public Work? GetItemById(int id);
        public IQueryable<Work> GetItems();
        public void Delete(ICollection<Work> items);
        public void SaveChanges(ICollection<Work> items); 
    }
}
