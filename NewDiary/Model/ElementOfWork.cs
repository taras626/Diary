namespace NewDiary.Model
{
    
    public class ElementOfWork
    {
        public int Id { get; set; }
        public ICollection<Work> Works { get; set; }
        public string NameElementOfWork { get; set; }    
        public SubGroupWork SubGroupWork { get; set; }
        public int Norm { get; set; }
    }
}
