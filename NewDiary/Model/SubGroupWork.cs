namespace NewDiary.Model
{
    public class SubGroupWork
    {
        public int Id { get; set; } 
        public string NameSubGroupWork { get; set; }
        public GroupWork GroupWork { get; set; }
        public ICollection<ElementOfWork> ElementsOfWorks { get; set; }
    }
}
