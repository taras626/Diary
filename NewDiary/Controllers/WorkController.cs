using Microsoft.AspNetCore.Mvc;
using NewDiary.Data;
using NewDiary.Model;
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

        // GET api/<WorkController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return JsonSerializer.Serialize(_dataManager.WorkRepository.GetItemById(id), _dataManager.options);
        }

        // POST api/<WorkController>
        [HttpPost]
        public void Post([FromBody] string jsonGroups)
        {
            ICollection<Work> newGroups = JsonSerializer.Deserialize<ICollection<Work>>(jsonGroups);

            if (newGroups == null)
                return;

            _dataManager.WorkRepository.SaveChanges(newGroups);
        }

        // DELETE api/<WorkController>/5
        [HttpDelete]
        public void Delete(string jsonGroups)
        {
            ICollection<Work> newGroups = JsonSerializer.Deserialize<ICollection<Work>>(jsonGroups);

            if (newGroups == null)
                return;

            _dataManager.WorkRepository.Delete(newGroups);
        }
    }
}
