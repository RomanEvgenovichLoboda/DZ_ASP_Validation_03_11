using Library.Models.Repositories;

namespace Library.Models
{
    public class UserWork
    {
        protected HostContext hostContext = null;
        protected UserRepos userRepos;
        public UserRepos UserRepos
        {
            get
            {
                if (userRepos == null) userRepos = new UserRepos(hostContext);
                return userRepos;
            }
        }
        public UserWork()
        {
            hostContext = new HostContext();
        }
        public void Dispose() => GC.SuppressFinalize(this);
    }
}
