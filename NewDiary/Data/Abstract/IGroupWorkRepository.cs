using Microsoft.EntityFrameworkCore;
using NewDiary.Model;

namespace NewDiary.Data.Abstract
{
    public interface IGroupWorkRepository
    {
        public GroupWork? GetItemById(int id);
        public IQueryable<GroupWork> GetItems();
        public void Delete(ICollection<GroupWork> items);
        public void SaveChanges(ICollection<GroupWork> items);
    }
}
