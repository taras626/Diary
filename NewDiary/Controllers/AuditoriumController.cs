using Microsoft.AspNetCore.Mvc;
using NewDiary.Data;
using NewDiary.Model;
using System.Text.Json;
using System.Text.Unicode;

namespace NewDiary.Controllers
{
    [Route("api/Auditorium")]
    [ApiController]
    public class AuditoriumController : ControllerBase
    {
        private readonly DataManager _dataManager;
        public AuditoriumController(DataManager dataManager)
        {
            _dataManager = dataManager;
        }

        // GET: api/Auditorium
        [HttpGet]
        public string Get()
        {
            return JsonSerializer.Serialize(_dataManager.AuditoriumRepository.GetItems(), _dataManager.options);
        }

        // GET api/Auditorium/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return JsonSerializer.Serialize(_dataManager.AuditoriumRepository.GetItemById(id), _dataManager.options); ;
        }

        // POST api/Auditorium
        [HttpPost]
        public void Post([FromBody] JsonDocument jsonAuditoriums)
        {
            ICollection<Auditorium> newGroups = JsonSerializer.Deserialize<ICollection<Auditorium>>(jsonAuditoriums, _dataManager.options);

            if (newGroups == null)
                return;

            _dataManager.AuditoriumRepository.SaveChanges(newGroups);
        }

        // DELETE api/Auditorium
        [HttpDelete]
        public void Delete([FromBody] JsonDocument jsonAuditoriums)
        {
            ICollection<Auditorium> newAuditoriums = JsonSerializer.Deserialize<ICollection<Auditorium>>(jsonAuditoriums, _dataManager.options);

            if (newAuditoriums == null)
                return;

            _dataManager.AuditoriumRepository.Delete(newAuditoriums);
        }
    }
}
