namespace NewDiary.Model
{
    public class Auditorium
    {
        //Первичный ключ для Аудитории
        public int IdAuditorium { get; set; }
        public string Name { get; set; }
        public ICollection<Computer> Computers { get; set; }
    }
}
