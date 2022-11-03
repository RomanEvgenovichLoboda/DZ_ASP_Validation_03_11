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
        public UserController() { work = new UserWork(); }
        [HttpGet("GetUsersNames")]
        public IEnumerable<string>GetUsersNames()=>work.UserRepos.GetUsersNames();
        [HttpGet("GetUsers")]
        public IEnumerable<User> GetUsers() => work.UserRepos.GetUsers();
        [HttpPost("Registration")]
        public HttpStatusCode Registration([FromForm]DataModel dataModel)
        {
            if (!TryValidateModel(dataModel,nameof(DataModel)))return HttpStatusCode.BadRequest;
            ModelState.ClearValidationState(nameof(DataModel));
            return work.UserRepos.Add(dataModel);
        }
        [HttpPost("Autorisation")]
        public HttpStatusCode Autorisation([FromForm] DataModel dataModel)
        {
            if (!TryValidateModel(dataModel, nameof(DataModel))) return HttpStatusCode.BadRequest;
            ModelState.ClearValidationState(nameof(DataModel));
            return work.UserRepos.Search(dataModel);
        }
        [HttpPost("ChengePassword")]
        public HttpStatusCode ChengePassword([FromForm] ChengeDataModel chengeData)
        {
            if (!TryValidateModel(chengeData, nameof(ChengeDataModel))) return HttpStatusCode.BadRequest;
            ModelState.ClearValidationState(nameof(ChengeDataModel));
            return work.UserRepos.ChengePassword(chengeData);
        }
    }
}
