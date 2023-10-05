using Microsoft.AspNetCore.Mvc;
using NewDiary.Data;
using NewDiary.Model;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Unicode;

namespace NewDiary.Controllers
{
    [Route("api/Department")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly DataManager _dataManager;
        public DepartmentController(DataManager dataManager)
        {
            _dataManager = dataManager;
        }

        // GET: api/Department
        [HttpGet]
        public string Get()
        {
            return JsonSerializer.Serialize(_dataManager.DepartmentRepository.GetItems(), _dataManager.options);
        }

        // GET api/Department/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return JsonSerializer.Serialize(_dataManager.DepartmentRepository.GetItemById(id), _dataManager.options); ;
        }

        // POST api/Department
        [HttpPost]
        public void Post([FromBody] JsonDocument jsonDepartments)
        {
            ICollection<Department> newGroups = JsonSerializer.Deserialize<ICollection<Department>>(jsonDepartments, _dataManager.options);

            if (newGroups == null)
                return;

            _dataManager.DepartmentRepository.SaveChanges(newGroups);
        }

        // DELETE api/Department
        [HttpDelete]
        public void Delete([FromBody] JsonDocument jsonDepartments)
        {
            ICollection<Department> newGroups = JsonSerializer.Deserialize<ICollection<Department>>(jsonDepartments, _dataManager.options);

            if (newGroups == null)
                return;

            _dataManager.DepartmentRepository.Delete(newGroups);
        }
    }
}
