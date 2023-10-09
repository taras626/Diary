namespace NewDiary.Model
{
    public class GroupWork
    {
        public int Id { get; set; }
        public string NameGroupWork { get; set; }
        public ICollection<SubGroupWork> SubGroupsWork { get; set; }
    }
}
