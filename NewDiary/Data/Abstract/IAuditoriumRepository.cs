using Microsoft.EntityFrameworkCore;
using NewDiary.Model;

namespace NewDiary.Data.Abstract
{
    public interface IAuditoriumRepository
    {
        public Auditorium? GetItemById(int id);
        public IQueryable<Auditorium> GetItems();
        public void Delete(ICollection<Auditorium> items);
        public void SaveChanges(ICollection<Auditorium> items);
    }
}
