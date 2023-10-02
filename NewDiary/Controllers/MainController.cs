using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using NewDiary.Data;
using NewDiary.Data.EntityFramework;
using NewDiary.Model;

namespace NewDiary.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MainController : ControllerBase
    {
        private readonly ILogger<MainController> _logger;
        private readonly DataManager _dataManager;
        public MainController(ILogger<MainController> logger, DataManager dataManager)
        {
            _logger = logger;
            _dataManager = dataManager;
        }

        [HttpGet(Name = "GetApi/Departments")]
        public IResult GetAllDepartments()
        {
            return Results.Json(_dataManager.DepartmentRepository.GetItems());
        }

        //[HttpPost(Name = "PostApi/Departments")]
        //public void PostAllDepartments(string jsonDepartments)
        //{
        //    ICollection<Department>? departments = JsonSerializer.Deserialize<ICollection<Department>>(jsonDepartments);

        //    if (departments == null)
        //        return;

        //    _dataManager.DepartmentRepository.SaveChanges(departments);
        //}
    }
}