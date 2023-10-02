namespace NewDiary.Model
{
    
    public class ElementOfWork
    {
        public int IdElementOfWork { get; set; }
        public string Name { get; set; }    
        public SubGroupWork SubGroupWork { get; set; }
        public int Norm { get; set; }
    }
}
