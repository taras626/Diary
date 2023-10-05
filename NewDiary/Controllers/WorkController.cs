using Microsoft.AspNetCore.Mvc;
using NewDiary.Data;
using NewDiary.Model;
using NewDiary.Model.QueryModels;
using System.Text.Json;



namespace NewDiary.Controllers
{
    [Route("api/Work")]
    [ApiController]
    public class WorkController : ControllerBase
    {
        private readonly DataManager _dataManager;
        public WorkController(DataManager dataManager)
        {
            _dataManager = dataManager;
        }

        [HttpGet("{id}")]
        public string GetWorkById(int id)
        {
            return JsonSerializer.Serialize(_dataManager.WorkRepository.GetItemById(id), _dataManager.options);
        }


        [HttpGet("api/Work/ByEmployee")]
        public string GetByEmployee([FromBody] JsonDocument jsonEmployee)
        {
            QueryEmployee queryEmployee = JsonSerializer.Deserialize<QueryEmployee>(jsonEmployee);

            if (queryEmployee == null) 
            {
                return null;
            }

            return JsonSerializer.Serialize(_dataManager.WorkRepository.GetItemsByEmployee(queryEmployee.Employee, queryEmployee.BeginTime, queryEmployee.EndTime), _dataManager.options);
        }

        [HttpGet("api/Work/ByDepartment")] 
        public string GetByDepartment([FromBody] JsonDocument jsonDepartment) 
        {
            QueryDepartment queryDepartment = JsonSerializer.Deserialize<QueryDepartment>(jsonDepartment);

            if (queryDepartment == null)
                return null;

            return JsonSerializer.Serialize<ICollection<Work>>(_dataManager.WorkRepository.GetItemsByDepartment(queryDepartment.Department, queryDepartment.BeginTime, queryDepartment.EndTime).ToList(), _dataManager.options);
        }

        // POST api/<WorkController>
        [HttpPost]
        public void Post([FromBody] JsonDocument jsonWorks)
        {
            ICollection<Work> newGroups = JsonSerializer.Deserialize<ICollection<Work>>(jsonWorks);

            if (newGroups == null)
                return;

            _dataManager.WorkRepository.SaveChanges(newGroups);
        }

        // DELETE api/<WorkController>/5
        [HttpDelete]
        public void Delete([FromBody] JsonDocument jsonWorks)
        {
            ICollection<Work> newGroups = JsonSerializer.Deserialize<ICollection<Work>>(jsonWorks);

            if (newGroups == null)
                return;

            _dataManager.WorkRepository.Delete(newGroups);
        }
    }
}
