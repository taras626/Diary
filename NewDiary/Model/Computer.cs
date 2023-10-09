namespace NewDiary.Model
{
    public class Computer
    {
        public int Id { get; set; }
        
        public ICollection<Work> Work { get; set; }
        public string NameComputer { get; set; }
        public bool IsUsed { get; set; }
        //Внешний ключ для Аудитории
        public Auditorium Auditorium { get; set; }
    }
}
