using Microsoft.AspNetCore.Mvc;
using NewDiary.Data;
using NewDiary.Model;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Unicode;

namespace NewDiary.Controllers
{
    [Route("api/Employee")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly DataManager _dataManager;
        public EmployeeController(DataManager dataManager)
        {
            _dataManager = dataManager;
        }

        // GET: api/Employee
        [HttpGet]
        public string Get()
        {
            return JsonSerializer.Serialize(_dataManager.EmployeeRepository.GetItems(), _dataManager.options);
        }

        // GET api/Employee/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return JsonSerializer.Serialize(_dataManager.EmployeeRepository.GetItemById(id), _dataManager.options); ;
        }

        // POST api/Employee
        [HttpPost]
        public void Post([FromBody] JsonDocument jsonEmployees)
        {
            ICollection<Employee> newGroups = JsonSerializer.Deserialize<ICollection<Employee>>(jsonEmployees, _dataManager.options);

            if (newGroups == null)
                return;

            _dataManager.EmployeeRepository.SaveChanges(newGroups);
        }

        // DELETE api/Employee
        [HttpDelete]
        public void Delete([FromBody] JsonDocument jsonEmployees)
        {
            ICollection<Employee> newGroups = JsonSerializer.Deserialize<ICollection<Employee>>(jsonEmployees, _dataManager.options);

            if (newGroups == null)
                return;

            _dataManager.EmployeeRepository.Delete(newGroups);
        }
    }
}
