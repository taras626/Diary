namespace NewDiary.Model
{
    public class Department
    {
        public int IdDepartment { get; set; }
        public string NameDepartment { get; set; }
        public ICollection<Employee> EmployeeOfDepartment { get; set; }
    }
}
