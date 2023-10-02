namespace NewDiary.Model
{
    public class GroupWork
    {
        public int IdGroupWork { get; set; }
        public string Name { get; set; }
        public ICollection<Work> Works { get; set; }
        public ICollection<SubGroupWork> SubGroupsWork { get; set; }
    }
}
