using Microsoft.EntityFrameworkCore;
using NewDiary.Model;

namespace NewDiary.Data.Abstract
{
    public interface IElementOfWorkRepository
    {
        public ElementOfWork? GetItemById(int id);
        public IQueryable<ElementOfWork> GetItems();
        public void Delete(ICollection<ElementOfWork> items);
        public void SaveChanges(ICollection<ElementOfWork> items);
    }
}
