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
        public IEnumerable<string>GetUsers()=>context.Users.Select(it => it.Name);
        public bool AddUser(User entity)
        {
            foreach (var item in context.Users)
            {
                if (entity.Name == item.Name) return false;
            }
            context.Add(entity);
            context.SaveChanges();
            return true;
        }

        public HttpStatusCode Add(User user)
        {
            foreach (var item in context.Users)
            {
                if (user.Name == item.Name) return HttpStatusCode.Conflict;
            }
            context.Add(user);
            context.SaveChanges();
            return HttpStatusCode.OK;
        }
    }
}
