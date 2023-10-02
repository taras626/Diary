using Microsoft.AspNetCore.Mvc;
using NewDiary.Data;
using NewDiary.Model;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Unicode;

namespace NewDiary.Controllers
{
    [Route("api/ElementOfWork")]
    [ApiController]
    public class ElementOfWorkController : ControllerBase
    {
        private readonly DataManager _dataManager;
        public ElementOfWorkController(DataManager dataManager)
        {
            _dataManager = dataManager;
        }

        // GET: api/ElementOfWork
        [HttpGet]
        public string Get()
        {
            return JsonSerializer.Serialize(_dataManager.ElementOfWorkRepository.GetItems(), _dataManager.options);
        }

        // GET api/ElementOfWork/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return JsonSerializer.Serialize(_dataManager.ElementOfWorkRepository.GetItemById(id), _dataManager.options); ;
        }

        // POST api/ElementOfWork
        [HttpPost]
        public void Post([FromBody] JsonDocument jsonGroups)
        {
            ICollection<ElementOfWork> newGroups = JsonSerializer.Deserialize<ICollection<ElementOfWork>>(jsonGroups, _dataManager.options);

            if (newGroups == null)
                return;

            _dataManager.ElementOfWorkRepository.SaveChanges(newGroups);
        }

        // DELETE api/Department
        [HttpDelete]
        public void Delete([FromBody] string jsonGroups)
        {
            ICollection<ElementOfWork> newGroups = JsonSerializer.Deserialize<ICollection<ElementOfWork>>(jsonGroups, _dataManager.options);

            if (newGroups == null)
                return;

            _dataManager.ElementOfWorkRepository.Delete(newGroups);
        }
    }
}
