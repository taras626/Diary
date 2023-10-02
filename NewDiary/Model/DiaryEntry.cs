using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace NewDiary.Model
{
    public class DiaryEntry
    {
        public int IdDiaryEntry { get; set; }
        public Employee Employee { get; set; }        
        public int IdWork { get; set; }
        public Work ObjOfWork { get; set; }
    }
}
