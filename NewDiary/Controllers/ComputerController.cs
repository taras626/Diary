using Microsoft.AspNetCore.Mvc;
using NewDiary.Data;
using NewDiary.Model;
using System.Text.Json;
using System.Text.Unicode;

namespace NewDiary.Controllers
{
    [Route("api/Computer")]
    [ApiController]
    public class ComputerController : ControllerBase
    {
        private readonly DataManager _dataManager;
        public ComputerController(DataManager dataManager)
        {
            _dataManager = dataManager;
        }

        // GET: api/Computer
        [HttpGet]
        public string Get()
        {
            return JsonSerializer.Serialize(_dataManager.ComputerRepository.GetItems(), _dataManager.options);
        }

        // GET api/Computer/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return JsonSerializer.Serialize(_dataManager.ComputerRepository.GetItemById(id), _dataManager.options); ;
        }

        // POST api/Computer
        [HttpPost]
        public void Post(string jsonGroups)
        {
            ICollection<Computer> newGroups = JsonSerializer.Deserialize<ICollection<Computer>>(jsonGroups, _dataManager.options);

            if (newGroups == null)
                return;

            _dataManager.ComputerRepository.SaveChanges(newGroups);
        }

        // DELETE api/Computer
        [HttpDelete]
        public void Delete(string jsonGroups)
        {
            ICollection<Computer> newGroups = JsonSerializer.Deserialize<ICollection<Computer>>(jsonGroups, _dataManager.options);

            if (newGroups == null)
                return;

            _dataManager.ComputerRepository.Delete(newGroups);
        }
    }
}
