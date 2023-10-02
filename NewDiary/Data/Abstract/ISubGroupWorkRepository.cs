using Microsoft.EntityFrameworkCore;
using NewDiary.Model;

namespace NewDiary.Data.Abstract
{
    public interface ISubGroupWorkRepository
    {
        public SubGroupWork? GetItemById(int id);
        public IQueryable<SubGroupWork> GetItems();
        public void Delete(ICollection<SubGroupWork> items);
        public void SaveChanges(ICollection<SubGroupWork> items);
    }
}
