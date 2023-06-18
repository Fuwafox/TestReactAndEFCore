using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestReactAndEFCore.DBWorker;
using TestReactAndEFCore.Models;

namespace TestReactAndEFCore.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
   
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly DBWorkerUsers workerUsers;
        public UserController(ILogger<UserController> logger, DBWorkerUsers workerUsers)
        {
            _logger = logger;
            this.workerUsers = workerUsers;
        }

        [HttpPost]
        public void Add([FromBody] User user)
        {
            if (user == null)
            {
                _logger.LogError("Нет пользователей для добавления.");
            }
            workerUsers.Add(user);
        }

        [HttpGet]
        public IEnumerable<User> SelectAll() => workerUsers.SelectUsers();

    }
}
