using Library.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace DZ_ASP_Validation_03_11.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class UserController:Controller
    {
        UserWork work;
        public UserController()
        {
            work = new UserWork();
        }
        [HttpGet("GetUsersNames")]
        public IEnumerable<string>GetUsersNames()=>work.UserRepos.GetUsersNames();
        [HttpGet("GetUsers")]
        public IEnumerable<User> GetUsers() => work.UserRepos.GetUsers();
        [HttpPost("Registration")]
        public HttpStatusCode Registration([FromForm]DataModel dataModel)
        {
            User user = new User() { Name = dataModel.Login, Password = dataModel.Password };
            if (!TryValidateModel(user,nameof(User)))return HttpStatusCode.BadRequest;
            ModelState.ClearValidationState(nameof(User));
            return work.UserRepos.Add(user);
        }
        [HttpPost("Autorisation")]
        public HttpStatusCode Autorisation([FromForm] DataModel dataModel)
        {
            User user = new User() { Name = dataModel.Login, Password = dataModel.Password };
            if (!TryValidateModel(user, nameof(User))) return HttpStatusCode.BadRequest;
            ModelState.ClearValidationState(nameof(User));
            return work.UserRepos.Search(user);
        }
    }
}
