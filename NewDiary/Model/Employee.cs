namespace NewDiary.Model
{
    public class Employee
    {
        public int IdEmployee { get; set; }
        public ICollection<Work> Work { get; set; }
        public string Name { get; set; }
        public Department Department { get; set; }
    }
}
