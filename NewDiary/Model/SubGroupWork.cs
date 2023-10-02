namespace NewDiary.Model
{
    public class SubGroupWork
    {
        public int IdSubGroupWork { get; set; } 
        public string Name { get; set; }
        public GroupWork GroupWork { get; set; }
        public ICollection<ElementOfWork> ElementsOfWorks { get; set; }
    }
}
