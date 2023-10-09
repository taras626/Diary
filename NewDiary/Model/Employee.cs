namespace NewDiary.Model
{
    public class Employee
    {
        public int Id { get; set; }
        public ICollection<Work> Work { get; set; }
        public string NameEmployee { get; set; }
        public Department Department { get; set; }
    }
}
