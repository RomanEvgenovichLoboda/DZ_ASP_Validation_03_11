using System.Net;

namespace Library.Models.Repositories
{
    public class UserRepos
    {
        public HostContext context;
        public UserRepos(HostContext context)
        {
            this.context = context;
        }
        public IEnumerable<string>GetUsersNames()=>context.Users.Select(it => it.Name);
        public IEnumerable<User> GetUsers() => context.Users;
        public HttpStatusCode Add(DataModel user)
        {
            User? temp = context.Users.FirstOrDefault(x => x.Name == user.Login);
            if (temp != null) return HttpStatusCode.PreconditionFailed;
            temp = new User() { Name = user.Login, Password = user.Password };
            context.Add(temp);
            context.SaveChanges();
            return HttpStatusCode.Created;
        }
        public HttpStatusCode Search(DataModel user)
        {
            User? temp = context.Users.FirstOrDefault(x => x.Name == user.Login && x.Password == user.Password);
            if (temp != null) return HttpStatusCode.OK;
            return HttpStatusCode.Forbidden;//Not Acceptable
        }
        public HttpStatusCode ChengePassword(ChengeDataModel chengeData)
        {
            var temp = context.Users.FirstOrDefault(x => x.Name == chengeData.Login && x.Password == chengeData.Password);
            if(temp != null) 
            {
                temp.Password = chengeData.NewPassword;
                context.SaveChanges();
                return HttpStatusCode.OK;
            }
            return HttpStatusCode.NotAcceptable;
        }
    }
}
