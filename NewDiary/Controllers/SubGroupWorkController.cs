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

        // GET: api/<GroupWorkController>
        [HttpGet]
        public string Get()
        {
            return JsonSerializer.Serialize(_dataManager.SubGroupWorkRepository.GetItems(), _dataManager.options);
        }

        // GET api/<GroupWorkController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return JsonSerializer.Serialize(_dataManager.SubGroupWorkRepository.GetItemById(id), _dataManager.options);
        }

        // POST api/<GroupWorkController>
        [HttpPost]
        public void Post([FromBody] string jsonGroups)
        {
            ICollection<SubGroupWork> newGroups = JsonSerializer.Deserialize<ICollection<SubGroupWork>>(jsonGroups);

            if (newGroups == null)
                return;

            _dataManager.SubGroupWorkRepository.SaveChanges(newGroups);
        }

        // DELETE api/<GroupWorkController>/5
        [HttpDelete]
        public void Delete(string jsonGroups)
        {
            ICollection<SubGroupWork> newGroups = JsonSerializer.Deserialize<ICollection<SubGroupWork>>(jsonGroups);

            if (newGroups == null)
                return;

            _dataManager.SubGroupWorkRepository.Delete(newGroups);
        }
    }
}
