namespace NewDiary.Model
{
    public class Computer
    {
        public int IdComputer { get; set; }
        
        public ICollection<Work> Works { get; set; }
        public string Name { get; set; }
        
        //Внешний ключ для Аудитории
        public Auditorium Auditorium { get; set; }
    }
}
