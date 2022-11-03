using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

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
        public HttpStatusCode Add(User user)
        {
            User? temp = context.Users.FirstOrDefault(x => x.Name == user.Name);
            if (temp != null) return HttpStatusCode.PreconditionFailed;
            context.Add(user);
            context.SaveChanges();
            return HttpStatusCode.OK;
        }
        public HttpStatusCode Search(User user)
        {
            User? temp = context.Users.FirstOrDefault(x => x.Name == user.Name && x.Password == user.Password);
            if (temp != null) return HttpStatusCode.OK;
            return HttpStatusCode.Forbidden;//Not Acceptable
        }
    }
}
