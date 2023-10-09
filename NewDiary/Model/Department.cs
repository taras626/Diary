namespace NewDiary.Model
{
    public class Department
    {
        public int Id { get; set; }
        public string NameDepartment { get; set; }
        public ICollection<Employee> EmployeeOfDepartment { get; set; }
    }
}
