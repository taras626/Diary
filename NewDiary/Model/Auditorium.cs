namespace NewDiary.Model
{
    public class Auditorium
    {
        //Первичный ключ для Аудитории
        public int Id { get; set; }
        public string NameAuditorium { get; set; }
        public ICollection<Computer> Computers { get; set; }
    }
}
