using Microsoft.AspNetCore.Mvc;
using NewDiary.Data;
using NewDiary.Model;
using System.Text.Json;



namespace NewDiary.Controllers
{
    [Route("api/SubGroupWork")]
    [ApiController]
    public class SubGroupWorkController : ControllerBase
    {
        private readonly DataManager _dataManager;
        public SubGroupWorkController(DataManager dataManager)
        {
            _dataManager = dataManager;
        }

        // GET: api/SubGroupWork
        [HttpGet]
        public string Get()
        {
            return JsonSerializer.Serialize(_dataManager.SubGroupWorkRepository.GetItems(), _dataManager.options);
        }

        // GET api/SubGroupWork/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return JsonSerializer.Serialize(_dataManager.SubGroupWorkRepository.GetItemById(id), _dataManager.options);
        }

        // POST api/SubGroupWork
        [HttpPost]
        public void Post([FromBody] JsonDocument jsonSBWorks)
        {
            ICollection<SubGroupWork> newGroups = JsonSerializer.Deserialize<ICollection<SubGroupWork>>(jsonSBWorks);

            if (newGroups == null)
                return;

            _dataManager.SubGroupWorkRepository.SaveChanges(newGroups);
        }

        // DELETE api/SubGroupWork
        [HttpDelete]
        public void Delete([FromBody] JsonDocument jsonSBWorks)
        {
            ICollection<SubGroupWork> newGroups = JsonSerializer.Deserialize<ICollection<SubGroupWork>>(jsonSBWorks);

            if (newGroups == null)
                return;

            _dataManager.SubGroupWorkRepository.Delete(newGroups);
        }
    }
}
