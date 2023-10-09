using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace NewDiary.Model
{
    public class Work
    {
        public int Id { get; set; }
        public Employee Employee { get; set; }
        public string Description { get; set; }
        public DateTime DateOfCompletion { get; set; }
        public DateTime DateOfInput { get; set; }
        public ElementOfWork ElementOfWork { get; set; }
        public int CountOfEntities { get; set; }//Кол-во условных единиц
        public int TimeSpent { get; set; }
        public ICollection<Computer> Computer { get; set; }
    }
}
