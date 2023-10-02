using NewDiary.Data.Abstract;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;

namespace NewDiary.Data
{
    public class DataManager
    {
        public IAuditoriumRepository AuditoriumRepository { get; set; } 
        public IDepartmentRepository DepartmentRepository { get; set; }
        public IComputerRepository ComputerRepository { get; set; }
        public IEmployeeRepository EmployeeRepository { get; set; }
        public IGroupWorkRepository GroupWorkRepository { get; set; }
        public IWorkRepository WorkRepository { get; set; }
        public IDiaryEntryRepository DiaryEntryRepository { get; set; }

        public readonly JsonSerializerOptions options;

        public DataManager(
            IAuditoriumRepository AuditoriumRepository, 
            IDepartmentRepository DepartmentRepository, 
            IComputerRepository ComputerRepository, 
            IEmployeeRepository EmployeeRepository,
            IGroupWorkRepository GroupWorkRepository,
            IWorkRepository WorkRepository,
            IDiaryEntryRepository DiaryEntryRepository
            )
        {
            this.AuditoriumRepository = AuditoriumRepository;
            this.DepartmentRepository = DepartmentRepository;
            this.ComputerRepository = ComputerRepository;
            this.EmployeeRepository = EmployeeRepository;
            this.GroupWorkRepository = GroupWorkRepository;
            this.WorkRepository = WorkRepository;
            this.DiaryEntryRepository = DiaryEntryRepository;
            options = new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
                WriteIndented = true
            };
        }
    }
}
