using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace NewDiary.Model
{
    public class Work
    {
        public int IdWork { get; set; }
        [ForeignKey("DiaryEntry")]
        public DiaryEntry Entry { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime DateOfCompletion { get; set; }
        public GroupWork GroupOfThisWork { get; set; }
        public int CountOfEntities { get; set; }//Кол-во условных единиц
        public int TimeSpent { get; set; }
        public Computer UsedComputer { get; set; }
    }
}
