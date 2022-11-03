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
        [HttpGet("GetUsers")]
        public IEnumerable<string>GetUsers()=>work.UserRepos.GetUsers();
        [HttpPost("Registration")]
        public HttpStatusCode Registration([FromForm]User user)
        {
            if(!TryValidateModel(user,nameof(User)))return HttpStatusCode.BadRequest;
            ModelState.ClearValidationState(nameof(User));
            return work.UserRepos.Add(user);
            //work.UserRepos.AddUser(user);
            //return HttpStatusCode.OK;
        }
    }
}
