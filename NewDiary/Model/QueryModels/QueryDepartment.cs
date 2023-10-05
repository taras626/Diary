namespace NewDiary.Model.QueryModels
{
    public class QueryDepartment
    {
        public DateTime BeginTime { get; set; }
        public DateTime EndTime { get; set; }
        public Department Department { get; set;}
    }
}
