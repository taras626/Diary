using Microsoft.AspNetCore.Mvc;
using NewDiary.Data;
using NewDiary.Model;
using System.Text.Json;



namespace NewDiary.Controllers
{
    [Route("api/GroupWork")]
    [ApiController]
    public class GroupWorkController : ControllerBase
    {
        private readonly DataManager _dataManager;
        public GroupWorkController(DataManager dataManager)
        {
            _dataManager = dataManager;
        }

        // GET: api/<GroupWorkController>
        [HttpGet]
        public string Get()
        {
            return JsonSerializer.Serialize(_dataManager.GroupWorkRepository.GetItems(), _dataManager.options);
        }

        // GET api/<GroupWorkController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return JsonSerializer.Serialize(_dataManager.GroupWorkRepository.GetItemById(id), _dataManager.options);
        }

        // POST api/<GroupWorkController>
        [HttpPost]
        public void Post([FromBody] string jsonGroups)
        {
            ICollection<GroupWork> newGroups = JsonSerializer.Deserialize<ICollection<GroupWork>>(jsonGroups);

            if (newGroups == null)
                return;

            _dataManager.GroupWorkRepository.SaveChanges(newGroups);
        }

        // DELETE api/<GroupWorkController>/5
        [HttpDelete]
        public void Delete(string jsonGroups)
        {
            ICollection<GroupWork> newGroups = JsonSerializer.Deserialize<ICollection<GroupWork>>(jsonGroups);

            if (newGroups == null)
                return;

            _dataManager.GroupWorkRepository.Delete(newGroups);
        }
    }
}
